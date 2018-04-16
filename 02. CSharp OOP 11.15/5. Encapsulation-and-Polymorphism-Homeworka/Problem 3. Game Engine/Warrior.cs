using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum
{
    class Warrior : Character, IAttack
    {
        private const int WarriorDefaultHealth = 200;
        private const int WarriorDefaultAttack = 150;
        private const int WarriorDefaultDefense = 100;
        private const int WarriorDeafultRange = 2;

        public Warrior(string id, int x, int y, Team team) : base(id, x, y, WarriorDefaultHealth, WarriorDefaultDefense, team, WarriorDeafultRange)
        {
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var byTeam = targetsList.Where(t => this.Team != t.Team);
            return byTeam.FirstOrDefault(t => t.IsAlive);
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
            get { return WarriorDefaultAttack; }
            set { throw new NotImplementedException(); }
        }

        public override string ToString()
        {
            return base.ToString() + " Attack: " + WarriorDefaultAttack;
        }
    }
}
