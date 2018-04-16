namespace Blobs.Interfaces
{
    /// <summary>
    /// Interface of the Behavior factory
    /// </summary>
    public interface IBehaviorFactory
    {
        /// <summary>
        /// Creates a behavior from a string
        /// </summary>
        /// <param name="behaviorName">the name of the behavior being created</param>
        /// <returns>returns the created behavior</returns>
        IBehavior Create(string behaviorName);
    }
}