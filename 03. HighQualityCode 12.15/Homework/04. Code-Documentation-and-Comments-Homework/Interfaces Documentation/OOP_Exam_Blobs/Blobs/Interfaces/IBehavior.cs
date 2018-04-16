namespace Blobs.Interfaces
{
    /// <summary>
    ///  Blob's behavior
    /// </summary>
    public interface IBehavior
    {
        /// <summary>
        /// Triggers a behavior of a certain blob
        /// </summary>
        /// <param name="blob">the target of the triggered behavior</param>
        void Trigger(IBlob blob);

        /// <summary>
        /// Performs the negative part of an effect e.g take damage
        /// </summary>
        /// <param name="blob">the target of the negative effect</param>
        void PerformNegativeEffects(IBlob blob);

        /// <summary>
        /// Holds the state of the behavior if it's currently triggered or not
        /// </summary>
        bool IsTriggered { get; }

        /// <summary>
        /// Holds the state of the behavior if it has been triggered already or not
        /// </summary>
        bool AlreadyTriggered { get; }
    }
}