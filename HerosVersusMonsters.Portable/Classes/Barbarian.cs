using HerosVersusMonsters.Portable.Creatures;

namespace HerosVersusMonsters.Portable.Classes
{
    public class Barbarian : CreatureClassBase
    {
        public Barbarian(CreatureBase creatureBase) : base(creatureBase, CreatureClassType.Barbarian)
        {
        }
    }
}