using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HerosVersusMonsters.Portable.Classes;
using HerosVersusMonsters.Portable.Inventory;
using HerosVersusMonsters.Portable.Stats;
using Newtonsoft.Json;

namespace HerosVersusMonsters.Portable.Creatures
{
    public abstract class CreatureBase
    {
        protected CreatureBase(double agility, double charisma, double intelligence, double stamina, double strength,
            double wisdom, CreatureClassType creatureClassType)
        {
            CreatureClass = CreatureClassFactory.Create(creatureClassType, this);
            Stats = new Dictionary<StatType, Stat>
            {
                {StatType.Agility, new Stat(StatType.Agility, agility)},
                {StatType.Charisma, new Stat(StatType.Charisma, charisma)},
                {StatType.Intelligence, new Stat(StatType.Intelligence, intelligence)},
                {StatType.Stamina, new Stat(StatType.Stamina, stamina)},
                {StatType.Strength, new Stat(StatType.Strength, strength)},
                {StatType.Wisdom, new Stat(StatType.Wisdom, wisdom)}
            };
        }

        public Dictionary<ItemSlotType, InventoryItem> Slots { get; } = new Dictionary<ItemSlotType, InventoryItem>
        {
            {ItemSlotType.Cloak, null},
            {ItemSlotType.Feet, null},
            {ItemSlotType.Head, null},
            {ItemSlotType.Hands, null},
            {ItemSlotType.LeftHandRing, null},
            {ItemSlotType.Legs, null},
            {ItemSlotType.Neck, null},
            {ItemSlotType.RightHandRing, null},
            {ItemSlotType.Torso, null},
            {ItemSlotType.OneHandedWeapon, null},
            {ItemSlotType.TwoHandedWeapon, null},
            {ItemSlotType.Shield, null},
            {ItemSlotType.Waist, null}
        };

        public Dictionary<StatType, Stat> Stats { get; }

        public double Agility => Stats[StatType.Agility].StatValue;
        public double Charisma => Stats[StatType.Charisma].StatValue;
        public double Intelligence => Stats[StatType.Intelligence].StatValue;
        public double Stamina => Stats[StatType.Stamina].StatValue;
        public double Strength => Stats[StatType.Strength].StatValue;
        public double Wisdom => Stats[StatType.Wisdom].StatValue;
        public bool IsEncumbered { get; private set; }

        public List<InventoryItem> Inventory { get; } = new List<InventoryItem>();

        public List<Bonus> Bonuses { get; } = new List<Bonus>();

        public CreatureClassBase CreatureClass { get; }


        public void EquipItem(InventoryItem inventoryItem)
        {
            Debug.Assert(inventoryItem != null);
            Debug.Assert(inventoryItem.Slot != null,
                $"Cannot equip this item - no slot defined - {inventoryItem.ShortName}");
            if (!Inventory.Contains(inventoryItem))
            {
                AddToInventory(inventoryItem);
            }
            if (Slots[inventoryItem.Slot.Value] != null)
            {
                UnEquipItem(Slots[inventoryItem.Slot.Value], true);
            }
            Slots[inventoryItem.Slot.Value] = inventoryItem;
            RecalculateBonuses();
        }

        public void UnEquipItem(InventoryItem inventoryItem, bool deferBonusCalc = false)
        {
            Debug.Assert(inventoryItem != null);
            Debug.Assert(inventoryItem.IsEquipped = true,
                $"Cannot unequip an item that isn't equipped - {inventoryItem.ShortName}");
            Debug.Assert(Inventory.Contains(inventoryItem),
                $"Cannot unequip an item that isn't carried - {inventoryItem.ShortName}");
            Debug.Assert(inventoryItem.Slot != null,
                $"Cannot unequip this item - no slot defined - {inventoryItem.ShortName}");
            if (Slots[inventoryItem.Slot.Value] == inventoryItem)
            {
                Slots[inventoryItem.Slot.Value].IsEquipped = false;
                Slots[inventoryItem.Slot.Value] = null;
            }

            if (!deferBonusCalc)
            {
                RecalculateBonuses();
            }
        }

        private void RecalculateBonuses()
        {
            Bonuses.Clear();
            foreach (var inventoryItem in Slots.Values)
            {
                inventoryItem?.Bonuses.ForEach(b => Bonuses.Add(b));
            }
        }

        public void AddToInventory(InventoryItem inventoryItem)
        {
            Debug.Assert(inventoryItem != null);
            // we can have more than one of an item...
            Inventory.Add(inventoryItem);
            PerformEncumberedCheck();
        }

        public void RemoveFromInventory(InventoryItem inventoryItem)
        {
            Debug.Assert(inventoryItem != null);
            if (Inventory.Contains(inventoryItem))
            {
                Inventory.Remove(inventoryItem);
                PerformEncumberedCheck();
            }
        }

        private void PerformEncumberedCheck()
        {
            IsEncumbered = Inventory.Sum(i => i.Weight) > Strength*10;
        }

        public void EquipWeapon(Weapon weapon)
        {
            Debug.Assert(weapon != null);
            Debug.Assert(weapon.Slot == ItemSlotType.OneHandedWeapon || weapon.Slot == ItemSlotType.TwoHandedWeapon,
                $"Weapon {weapon.ShortName} has an invalid slot: {weapon.Slot}");

            if (weapon.Slot == ItemSlotType.OneHandedWeapon && Slots[ItemSlotType.TwoHandedWeapon] != null)
            {
                UnEquipItem(Slots[ItemSlotType.TwoHandedWeapon], true);
            }
            else if (weapon.Slot == ItemSlotType.TwoHandedWeapon)
            {
                if (Slots[ItemSlotType.OneHandedWeapon] != null)
                {
                    UnEquipItem(Slots[ItemSlotType.OneHandedWeapon], true);
                }

                if (Slots[ItemSlotType.Shield] != null)
                {
                    UnEquipItem(Slots[ItemSlotType.Shield], true);
                }
            }
            EquipItem(weapon);
        }

        public void EquipShield(Shield shield)
        {
            Debug.Assert(shield != null);
            Debug.Assert(shield.Slot == ItemSlotType.Shield,
                $"Shield {shield.ShortName} has an invalid slot: {shield.Slot}");

            if (Slots[ItemSlotType.TwoHandedWeapon] != null)
            {
                UnEquipItem(Slots[ItemSlotType.TwoHandedWeapon], true);
            }
            EquipItem(shield);
        }


        public string SerializeInventory()
        {
            return JsonConvert.SerializeObject(Inventory);
        }

        public void DeserializeInventory(string json)
        {
            var inventory = JsonConvert.DeserializeObject<List<InventoryItem>>(json);
            Inventory.Clear();
            foreach (var inventoryItem in inventory)
            {
                if (inventoryItem.IsEquipped)
                {
                    if (inventoryItem is Weapon)
                    {
                        EquipWeapon((Weapon) inventoryItem);
                    }
                    else if (inventoryItem is Shield)
                    {
                        EquipShield((Shield) inventoryItem);
                    }
                    else
                    {
                        EquipItem(inventoryItem);
                    }
                }
                else
                {
                    Inventory.Add(inventoryItem);
                }
            }
        }
    }
}