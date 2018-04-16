namespace Logger.Models
{
    using System;
    using global::Logger.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format(string message, string reportLevel)
        {
            string currentTime = DateTime.Now.ToString();

            return string.Format(currentTime + " - " + reportLevel + " - " + message);
        }
    }
}
