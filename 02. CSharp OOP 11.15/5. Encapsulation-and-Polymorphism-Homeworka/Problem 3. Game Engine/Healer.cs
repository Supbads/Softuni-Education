using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum
{
    class Healer : Character, IHeal
    {
        private const int HealerDefaultHealth = 75;
        private const int HealerDefaultDefense = 50;
        private const int HealerDeafultRange = 6;
        private const int HealerDefaultHealing = 60;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, HealerDefaultHealth, HealerDefaultDefense, team, HealerDeafultRange)
        {

        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var byTeam = targetsList.Where(t => t.Team == this.Team);
            var byHp = byTeam.OrderBy(t => t.HealthPoints);
            return byHp.FirstOrDefault();
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }

        public int HealingPoints
        {
            get { return HealerDefaultHealing; }
            set { }
        }

        public override string ToString()
        {
            return base.ToString() + " Healing: " + this.HealingPoints;
        }
    }
}
