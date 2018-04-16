namespace TheSlum
{
    using Interfaces;

    public abstract class Bonus : Item, ITimeoutable
    {
        protected Bonus(string id, int healthEffect, int defenseEffect, int attackEffect)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
        }

        public virtual int Timeout { get; set; }

        public virtual int Countdown { get; set; }

        public bool HasTimedOut { get; set; }
    }
}
