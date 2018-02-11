using HerosVersusMonsters.Portable.Creatures;

namespace HerosVersusMonsters.Portable.Classes
{
    public class Monster : CreatureClassBase
    {
        public Monster(CreatureBase creatureBase) : base(creatureBase, CreatureClassType.Monster)
        {
        }
    }
}