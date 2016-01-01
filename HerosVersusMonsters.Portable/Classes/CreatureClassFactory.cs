using System;
using HerosVersusMonsters.Portable.Creatures;

namespace HerosVersusMonsters.Portable.Classes
{
    public static class CreatureClassFactory
    {
        public static CreatureClassBase Create(CreatureClassType creatureClassType, CreatureBase creatureBase)
        {
            switch (creatureClassType)
            {
                case CreatureClassType.Monster:
                    return new Monster(creatureBase);
                case CreatureClassType.Warrior:
                    return new Warrior(creatureBase);
                case CreatureClassType.Barbarian:
                    return new Barbarian(creatureBase);
                case CreatureClassType.Monk:
                    return new Monk(creatureBase);
                case CreatureClassType.Cleric:
                    return new Cleric(creatureBase);
                case CreatureClassType.Thief:
                    return new Thief(creatureBase);
                case CreatureClassType.Mage:
                    return new Mage(creatureBase);
                default:
                    throw new ArgumentOutOfRangeException(nameof(creatureClassType), creatureClassType, null);
            }
        }
    }
}