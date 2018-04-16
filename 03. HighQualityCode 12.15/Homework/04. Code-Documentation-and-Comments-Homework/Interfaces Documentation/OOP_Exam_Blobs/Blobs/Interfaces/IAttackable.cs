namespace Blobs.Interfaces
{
    using Models.EventHandlers;

    /// <summary>
    /// Interface indicated that an entity can be attacked
    /// </summary>
    public interface IAttackable
    {
        /// <summary>
        /// Responds to an attack
        /// </summary>
        /// <param name="damage">Responds to damage in a particular way e.g
        ///  lower the damage inflicted by the attacker</param>
        void Respond(int damage);

        /// <summary>
        /// Event triggers when a unit dies
        /// </summary>
        event BlobDeadEventHandler OnBlobDead;
    }
}