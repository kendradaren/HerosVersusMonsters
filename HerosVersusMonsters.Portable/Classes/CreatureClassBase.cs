using System.Linq;
using HerosVersusMonsters.Portable.Creatures;
using HerosVersusMonsters.Portable.Stats;

namespace HerosVersusMonsters.Portable.Classes
{
    public abstract class CreatureClassBase
    {
        private readonly CreatureBase _creatureBase;
        private readonly CreatureClassType _creatureClassType;

        protected CreatureClassBase(CreatureBase creatureBase, CreatureClassType creatureClassType)
        {
            _creatureBase = creatureBase;
            _creatureClassType = creatureClassType;
        }

        public virtual double DetermineAttack(CreatureBase target)
        {
            // default assumes just strength
            return _creatureBase.Strength +
                   _creatureBase.Bonuses.Where(b => b.StatType == StatType.Strength).Sum(b => b.StatValue) +
                   Dice.D20Roll();
        }

        public virtual double DetermineDefense()
        {
            // assume agility and armor
            return _creatureBase.Agility +
                   _creatureBase.Bonuses.Where(b => b.StatType == StatType.Agility).Sum(b => b.StatValue) +
                   _creatureBase.Bonuses.Where(b => b.StatType == StatType.Armor).Sum(b => b.StatValue) +
                   Dice.D20Roll();
        }
    }
}