namespace ApplicationWithLogger
{
    using Logger;
    using Logger.Interfaces;
    using Logger.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            ILayout layout = new SimpleLayout();

            IAppender consoleAppender = new ConsoleAppender(layout);
            consoleAppender.ReportLevel = ReportLevel.Error;
            IAppender fileAppender = new FileAppender(layout, @"..\..\log.txt");
            fileAppender.ReportLevel = ReportLevel.Info;

            ILogger logger = new Logger(consoleAppender, fileAppender);

            logger.Info("Everything seems fine");
            logger.Warn("Warning: Ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}
