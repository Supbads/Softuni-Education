using System;

namespace _05.Football_Team_Generator
{
    class Stats
    {
        private const int StatMin = 0;
        private const int StatMax = 100;

        private int endurance;
        private int spirit;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int spirit, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Spirit = spirit;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => endurance;
            set
            {
                if (value < StatMin || value > StatMax)
                {
                    throw new Exception("Endurance should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        public int Spirit
        {
            get => spirit;
            set
            {
                if (VallidateStat(value))
                {
                    throw new Exception("Spirit should be between 0 and 100.");
                }

                this.spirit = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            set
            {
                if (VallidateStat(value))
                {
                    throw new Exception("Dribble should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            set
            {
                if (VallidateStat(value))
                {
                    throw new Exception("Passing should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            set
            {
                if (VallidateStat(value))
                {
                    throw new Exception("Shooting should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        private static bool VallidateStat(int value)
        {
            return value < StatMin || value > StatMax;
        }

    }
}