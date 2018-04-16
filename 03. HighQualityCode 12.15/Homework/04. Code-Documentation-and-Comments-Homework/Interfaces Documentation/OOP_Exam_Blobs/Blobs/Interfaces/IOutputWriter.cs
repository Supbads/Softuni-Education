namespace Blobs.Interfaces
{
    /// <summary>
    /// Output writer's interface
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Writes an output message
        /// </summary>
        /// <param name="output">The output message that will be written</param>
        void Write(string output);
    }
}
