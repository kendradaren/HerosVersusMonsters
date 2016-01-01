namespace HerosVersusMonsters.Portable
{
    public class Stat
    {
        public Stat(StatType statType, double statValue)
        {
            StatType = statType;
            StatValue = statValue;
        }

        public double StatValue { get; private set; }

        public StatType StatType { get; private set; }
    }
}