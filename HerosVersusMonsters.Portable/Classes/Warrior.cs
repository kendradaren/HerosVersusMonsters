using HerosVersusMonsters.Portable.Creatures;

namespace HerosVersusMonsters.Portable.Classes
{
    public class Warrior : CreatureClassBase
    {
        public Warrior(CreatureBase creatureBase) : base(creatureBase, CreatureClassType.Warrior)
        {
        }
    }
}