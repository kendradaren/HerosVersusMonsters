using System.Diagnostics;

namespace HerosVersusMonsters.Portable
{
    public class Weapon : InventoryItem
    {
        private ItemSlotType? _slot;
        public double Damage { get; set; }

        public override ItemSlotType? Slot
        {
            get { return _slot; }
            set
            {
                Debug.Assert(value == ItemSlotType.OneHandedWeapon || value == ItemSlotType.TwoHandedWeapon,
                    $"Weapon slot cannot be {value}");
                _slot = value;
            }
        }
    }
}