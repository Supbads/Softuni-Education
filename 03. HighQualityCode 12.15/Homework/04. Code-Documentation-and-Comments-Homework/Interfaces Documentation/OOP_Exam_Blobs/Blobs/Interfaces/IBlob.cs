namespace Blobs.Interfaces
{
    using Models.EventHandlers;

    /// <summary>
    /// Blob's interface
    /// </summary>
    public interface IBlob : IAttackable, IAttacker, IUpdateable
    {
        /// <summary>
        /// Gets the name of the blob
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Gets and sets the health of the blob
        /// </summary>
        int Health { get; set; }
        
        /// <summary>
        /// Gets and sets the damage of the blob
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// Gets the state of the blob if it's alive or dead
        /// </summary>
        bool IsAlive { get; }
        
        /// <summary>
        /// Gets the behavior of the blob
        /// </summary>
        IBehavior Behavior { get; }
        
        /// <summary>
        /// Gets the attack of the blob
        /// </summary>
        IAttack Attack { get; }

        /// <summary>
        /// Event is triggered when a blob's behavior is toggled
        /// </summary>
        event BehaviorToggledEventHandler OnBehaviorToggled;
    }
}