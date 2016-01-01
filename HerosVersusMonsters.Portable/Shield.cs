using System.Diagnostics;

namespace HerosVersusMonsters.Portable
{
    public class Shield : ArmorItem
    {
        private ItemSlotType? _slot;

        public override ItemSlotType? Slot
        {
            get { return _slot; }
            set
            {
                Debug.Assert(value == ItemSlotType.Shield, "Shields can only have a Shield slot");
                _slot = value;
            }
        }
    }
}