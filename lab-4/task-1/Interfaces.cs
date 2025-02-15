namespace task_1
{
    public interface ISupportHandler
    {
        void SetNext(ISupportHandler handler);
        void Handle(string request);
        void DisplayMenu();
    }

    public interface ILogger
    {
        void Log(string message);
    }
}
