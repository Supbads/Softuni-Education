using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Football_Team_Generator
{
    class FootballTeam
    {
        private string name;

        public FootballTeam(string name)
        {
            this.Name = name;
            this.Team = new List<Player>();
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

        public List<Player> Team { get; set; }

        public double CalculateRating()
        {
            if (Team.Count == 0)
            {
                throw new Exception($"{Name} - 0");
            }

            return Math.Ceiling(this.Team.Average(x => x.AverageStats));
        }

        public void AddPlayer(Player player)
        {
            this.Team.Add(player);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.name, this.CalculateRating());
        }
    }
}