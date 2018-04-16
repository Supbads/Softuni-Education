namespace Logger.Models
{
    using System;
    using global::Logger.Interfaces;

    public class ConsoleAppender : IAppender
    {
        private readonly ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public void AppendMessage(string message, ReportLevel reportLevel)
        {
            if (this.ValidateReportLevel(reportLevel))
            {
                string formattedMessage = this.layout.Format(message, reportLevel.ToString());
                Console.WriteLine(formattedMessage);
            }
        }

        private bool ValidateReportLevel(ReportLevel curentReportLevel)
        {
            if (this.ReportLevel <= curentReportLevel)
            {
                return true;
            }

            return false;
        }
    }
}
