namespace Blobs.Interfaces
{
    /// <summary>
    /// Input reader's interface
    /// </summary>
    public interface IInputReader
    {
        /// <summary>
        /// Reads input
        /// </summary>
        /// <returns>Returns the read input as a string</returns>
        string Read();
    }
}