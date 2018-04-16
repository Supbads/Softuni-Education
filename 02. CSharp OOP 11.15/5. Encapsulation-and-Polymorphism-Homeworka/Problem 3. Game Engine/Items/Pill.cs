namespace TheSlum.Items
{
    class Pill : Bonus
    {
        private const int Duration = 1;
        private const int PillAttackBonus = 100;
        private const int PillHealthBonus = 0;
        private const int PillDefenseBonus = 0;

        public Pill(string id)
            : base(id, PillHealthBonus, PillDefenseBonus, PillAttackBonus)
        {
            this.Countdown = Duration;
            this.Timeout = Duration;
            this.HasTimedOut = false;
        }
    }
}
