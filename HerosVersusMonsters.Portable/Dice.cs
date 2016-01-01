using System;

namespace HerosVersusMonsters.Portable
{
    public static class Dice
    {
        private static readonly Random RandomSeed = new Random();

        public static double D6Roll()
        {
            return DiceRoll(6);
        }

        public static double D10Roll()
        {
            return DiceRoll(10);
        }

        public static double D12Roll()
        {
            return DiceRoll(12);
        }

        public static double D20Roll()
        {
            return DiceRoll(20);
        }

        public static double D100Roll()
        {
            return DiceRoll(100);
        }

        public static double D6X2Roll()
        {
            return DiceRoll(6) + DiceRoll(6);
        }

        private static double DiceRoll(int maxNumber)
        {
            return RandomSeed.Next(1, maxNumber + 1);
        }
    }
}