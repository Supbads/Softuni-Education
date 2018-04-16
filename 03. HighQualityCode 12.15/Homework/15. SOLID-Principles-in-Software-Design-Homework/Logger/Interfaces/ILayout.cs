namespace Logger.Interfaces
{
    public interface ILayout
    {
        string Format(string message, string reportLevel);
    }
}
