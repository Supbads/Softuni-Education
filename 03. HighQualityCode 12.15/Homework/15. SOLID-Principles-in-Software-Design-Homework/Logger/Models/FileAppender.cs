namespace Logger.Models
{
    using System.IO;

    using global::Logger.Interfaces;

    public class FileAppender : IAppender
    {
        private readonly ILayout layout;

        private readonly string filePath;

        public FileAppender(ILayout layout, string filePath)
        {
            this.layout = layout;
            this.filePath = filePath;
        }

        public ReportLevel ReportLevel { get; set; }

        public void AppendMessage(string message, ReportLevel reportLevel)
        {
            if (!this.ValidateReportLevel(reportLevel))
            {
                return;
            }

            using (var streamWriter = new StreamWriter(this.filePath, true))
            {
                string formattedMessage = this.layout.Format(message, reportLevel.ToString());
                streamWriter.WriteLine(formattedMessage);
            }
        }

        private bool ValidateReportLevel(ReportLevel curentReportLevel)
        {
            return this.ReportLevel <= curentReportLevel;
        }
    }
}
