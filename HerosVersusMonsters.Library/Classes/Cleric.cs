using HerosVersusMonsters.Portable.Creatures;

namespace HerosVersusMonsters.Portable.Classes
{
    public class Cleric : CreatureClassBase
    {
        public Cleric(CreatureBase creatureBase) : base(creatureBase, CreatureClassType.Cleric)
        {
        }
    }
}