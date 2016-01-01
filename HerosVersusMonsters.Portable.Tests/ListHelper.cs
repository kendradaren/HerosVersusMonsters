using System;

namespace HerosVersusMonsters.Portable.Tests
{
    public static class ListHelper
    {
        private static readonly Random RandomSeed = new Random();

        public static string GenerateName(string[] first, string[] second)
        {
            return $"{first[RandomSeed.Next(first.Length)]} {second[RandomSeed.Next(second.Length)]}";
        }
    }
}