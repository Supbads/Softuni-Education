namespace Logger.Models
{
    using global::Logger.Interfaces;

    public class Logger : ILogger
    {
        private readonly IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string message)
        {
            ReportLevel curentReportLevel = ReportLevel.Info;
            foreach (IAppender appender in this.appenders)
            {
                appender.AppendMessage(message, curentReportLevel);
            }
        }

        public void Warn(string message)
        {
            ReportLevel curentReportLevel = ReportLevel.Warn;
            foreach (IAppender appender in this.appenders)
            {
                appender.AppendMessage(message, curentReportLevel);
            }
        }

        public void Error(string message)
        {
            ReportLevel curentReportLevel = ReportLevel.Error;
            foreach (IAppender appender in this.appenders)
            {
                appender.AppendMessage(message, curentReportLevel);
            }
        }

        public void Critical(string message)
        {
            ReportLevel curentReportLevel = ReportLevel.Critical;
            foreach (IAppender appender in this.appenders)
            {
                appender.AppendMessage(message, curentReportLevel);
            }
        }

        public void Fatal(string message)
        {
            ReportLevel curentReportLevel = ReportLevel.Fatal;
            foreach (IAppender appender in this.appenders)
            {
                appender.AppendMessage(message, curentReportLevel);
            }
        }
    }
}
