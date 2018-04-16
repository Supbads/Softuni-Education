using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum
{
    class Mage : Character,IAttack
    {
        private const int MageDefaultHealth = 150;
        private const int MageDefaultAttack = 300;
        private const int MageDefaultDefense = 50;
        private const int MageDeafultRange = 5;

        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, MageDefaultHealth, MageDefaultDefense, team, MageDeafultRange)
        {

        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var byTeam = targetsList.Where(t => this.Team != t.Team);
            return byTeam.LastOrDefault(c => c.IsAlive);
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }

        public int AttackPoints
        {
            get { return MageDefaultAttack; }
            set { }
        }

        public override string ToString()
        {
            return base.ToString() + " Attack: " + MageDefaultAttack;
        }
    }
}
