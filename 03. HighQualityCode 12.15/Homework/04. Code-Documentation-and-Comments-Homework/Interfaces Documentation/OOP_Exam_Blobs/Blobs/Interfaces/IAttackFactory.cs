namespace Blobs.Interfaces
{
    /// <summary>
    /// In
    /// </summary>
    public interface IAttackFactory
    {
        /// <summary>
        /// Creates an attack from a given attack name
        /// </summary>
        /// <param name="attackName">name of the attack to be created</param>
        /// <returns>retruns the created attack</returns>
        IAttack Create(string attackName);
    }
}