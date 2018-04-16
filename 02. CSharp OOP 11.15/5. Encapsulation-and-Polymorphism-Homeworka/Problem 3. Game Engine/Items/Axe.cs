namespace TheSlum.Items
{
    class Axe : Item
    {
        private const int AxeDefaultHealthEffect = 0;
        private const int AxeDefaultDefenseEffect = 0;
        private const int AxeDefaultAttackEffect = 75;

        public Axe(string id)
            : base(id, AxeDefaultHealthEffect, AxeDefaultDefenseEffect, AxeDefaultAttackEffect)
        {
        }
    }
}
