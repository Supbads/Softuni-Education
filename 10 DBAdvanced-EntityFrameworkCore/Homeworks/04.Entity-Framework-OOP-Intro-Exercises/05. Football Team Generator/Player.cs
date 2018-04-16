using System;

namespace _05.Football_Team_Generator
{
    class Player
    {
        private string name;
        private double averageStats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
            this.AverageStats = CalculateAverageStats();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == "")
                {
                    throw new Exception("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public Stats Stats { get; set; }

        public double AverageStats
        {
            get => this.averageStats;
            private set { this.averageStats = value; }
        }

        private double CalculateAverageStats()
        {
            return (double) (Stats.Dribble + Stats.Endurance + Stats.Passing + Stats.Shooting + Stats.Spirit) / 5;

        }

    }
}