namespace Blobs.Interfaces
{
    /// <summary>
    /// Interfaces indicated that an entity can attack
    /// </summary>
    public interface IAttacker
    {
        /// <summary>
        /// Performs an attack via damage or special effects
        /// </summary>
        /// <param name="target">The target of the current attack</param>
        void PerformAttack(IBlob target);
    }
}