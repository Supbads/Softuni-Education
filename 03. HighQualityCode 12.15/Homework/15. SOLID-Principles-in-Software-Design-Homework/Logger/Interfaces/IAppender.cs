namespace Logger.Interfaces
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void AppendMessage(string message, ReportLevel reportLevel);
    }
}
