using System;
using System.Collections.Generic;

namespace HerosVersusMonsters.Portable.Tests
{
    public static class InventoryHelper
    {
        private static readonly Random RandomSeed = new Random();
        private static readonly string[] WeaponModifier = {"Great", "Rusty", "Bent", "Sharp", "New", "Pathetic"};

        private static readonly string[] WeaponType =
        {
            "Dagger", "Short Sword", "Sword", "Axe", "Spear", "Hammer",
            "Mace"
        };

        private static readonly string[] ShieldModifier = {"Great", "Rusty", "Battered", "Holed", "New", "Pathetic"};
        private static readonly string[] ShieldType = {"Buckler", "Heater", "Kite"};
        private static readonly string[] ItemModifier = {"Worn", "Rusty", "Battered", "Rotten", "New", "Pathetic"};

        private static readonly string[] ItemType =
        {
            "Hat", "Gloves", "Tunic", "Leggings", "Shoes", "Sandals", "Mittens",
            "Belt", "Shirt", "Pants"
        };

        public static List<InventoryItem> BuildInventoryItems(int itemCount)
        {
            var items = new List<InventoryItem>(itemCount);

            while (itemCount-- > 0)
            {
                var random = RandomSeed.Next(10);
                switch (random)
                {
                    case 0:
                        items.Add(CreateWeapon());
                        break;
                    case 1:
                        items.Add(CreateShield());
                        break;
                    case 2:
                    case 3:
                    case 4:
                        items.Add(CreateArmorItem());
                        break;
                    default:
                        items.Add(CreateItem());
                        break;
                }
            }


            return items;
        }

        public static Weapon CreateWeapon()
        {
            var slot = RandomSeed.NextDouble() > 0.5 ? ItemSlotType.OneHandedWeapon : ItemSlotType.TwoHandedWeapon;
            return new Weapon
            {
                ShortName =
                    $"{(slot == ItemSlotType.OneHandedWeapon ? "One-Handed" : "Two-Handed")}  {ListHelper.GenerateName(WeaponModifier, WeaponType)}",
                Damage = RandomSeed.Next(2, 15),
                Description = "Random Generated Item",
                Price = RandomSeed.Next(10, 100),
                Slot = slot,
                Weight = RandomSeed.Next(5, 10),
                IsEquipped = RandomSeed.NextDouble() > 0.8
            };
        }

        public static Shield CreateShield()
        {
            return new Shield
            {
                ShortName = ListHelper.GenerateName(ShieldModifier, ShieldType),
                Armor = RandomSeed.Next(2, 7),
                Description = "Random Generated Item",
                Price = RandomSeed.Next(10, 100),
                Slot = ItemSlotType.Shield,
                Weight = RandomSeed.Next(5, 10),
                IsEquipped = RandomSeed.NextDouble() > 0.8
            };
        }

        public static ArmorItem CreateArmorItem()
        {
            var slot = RandomSeed.NextDouble() < 0.1 ? null : (ItemSlotType?) RandomSeed.Next(13);
            return new ArmorItem
            {
                ShortName = ListHelper.GenerateName(ShieldModifier, ShieldType),
                Armor = RandomSeed.Next(2, 7),
                Description = "Random Generated Item",
                Price = RandomSeed.Next(10, 100),
                Slot = slot,
                Weight = RandomSeed.Next(5, 10),
                IsEquipped = RandomSeed.NextDouble() > 0.8
            };
        }

        public static InventoryItem CreateItem()
        {
            var slot = RandomSeed.NextDouble() < 0.1 ? null : (ItemSlotType?) RandomSeed.Next(13);
            return new InventoryItem
            {
                ShortName = ListHelper.GenerateName(ItemModifier, ItemType),
                Description = "Random Generated Item",
                Price = RandomSeed.Next(6),
                Slot = slot,
                Weight = RandomSeed.Next(5),
                IsEquipped = RandomSeed.NextDouble() > 0.8
            };
        }
    }
}