namespace Blobs.Interfaces
{
    /// <summary>
    /// Entity's attack interface
    /// </summary>
    public interface IAttack
    {
        /// <summary>
        /// Executes an attack
        /// </summary>
        /// <param name="target">The target of the attack</param>
        /// <param name="damage">The damage of the attack</param>
        void ExecuteAttack(IBlob target, int damage);

        /// <summary>
        /// Executes effects on attacker
        /// </summary>
        /// <param name="attacker">The attacker</param>
        void ExecuteEffectsOnAttacker(IBlob attacker);
    }
}