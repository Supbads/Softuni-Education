namespace Blobs.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Game's database interface
    /// </summary>
    public interface IBlobData
    {
        /// <summary>
        /// Holds a collection of blobs
        /// </summary>
        IEnumerable<IBlob> Blobs { get; }

        /// <summary>
        /// Adds a blob to the collection of blobs
        /// </summary>
        /// <param name="blob">The blob to be added in the database collection</param>
        void AddBlob(IBlob blob);
    }
}