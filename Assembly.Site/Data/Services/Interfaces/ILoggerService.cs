namespace Assembly.Site.Data.Services.Interfaces
{
    public interface ILoggerService
    {
        void Info(string message);
        void Error(string message, Exception exception);
    }
}