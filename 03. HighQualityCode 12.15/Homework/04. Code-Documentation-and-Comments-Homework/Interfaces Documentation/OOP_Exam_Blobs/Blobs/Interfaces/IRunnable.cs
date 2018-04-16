namespace Blobs.Interfaces
{
    /// <summary>
    /// Interface indicates that an object can be run
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// Runs the object
        /// <example>The engine can run</example>
        /// <code>
        /// public class Engine : IRunnable
        /// {
        ///     Run()
        ///     {
        ///         //...
        ///     }
        /// }
        /// </code>
        /// </summary>
        void Run();
    }
}