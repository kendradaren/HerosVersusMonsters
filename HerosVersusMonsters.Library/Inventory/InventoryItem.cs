using System.Collections.Generic;
using HerosVersusMonsters.Portable.Stats;

namespace HerosVersusMonsters.Portable.Inventory
{
    public class InventoryItem
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double SellPrice => Price - Price * Globals.SellBackReduction;
        public double Weight { get; set; }
        public List<Bonus> Bonuses { get; } = new List<Bonus>();
        public bool IsEquipped { get; set; }
        public virtual ItemSlotType? Slot { get; set; }
    }
}