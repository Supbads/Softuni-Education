namespace Blobs.Interfaces
{
    /// <summary>
    /// BlobFactory's interface
    /// </summary>
    public interface IBlobFactory
    {
        /// <summary>
        /// Creates a blob by given parameters
        /// </summary>
        /// <param name="name">The name of the blob</param>
        /// <param name="health">The health of the blob</param>
        /// <param name="damage">The damage of the blob</param>
        /// <param name="behavior">The behvior of the blob</param>
        /// <param name="attack">The attack of the blob</param>
        /// <returns>returns the created blob</returns>
        IBlob Create(string name, int health, int damage, IBehavior behavior, IAttack attack);
    }
}