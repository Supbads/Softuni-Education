namespace TheSlum.Items
{
    class Injection : Bonus
    {
        private const int Duration = 3;
        private const int InjectionAttackBonus = 0;
        private const int InjectionHealthBonus = 300;
        private const int InjectionDefenseBonus = 0;
        public Injection(string id)
            : base(id, InjectionHealthBonus, InjectionDefenseBonus, InjectionAttackBonus)
        {
            this.Countdown = Duration;
            this.Timeout = Duration;
            this.HasTimedOut = false;
        }
    }
}
