using HerosVersusMonsters.Portable.Classes;

namespace HerosVersusMonsters.Portable.Creatures
{
    public class Hero : CreatureBase
    {
        public Hero(double agility, double charisma, double intelligence, double stamina, double strength, double wisdom, CreatureClassType creatureClassType)
            : base(agility, charisma, intelligence, stamina, strength, wisdom, creatureClassType)
        {
        }
    }
}