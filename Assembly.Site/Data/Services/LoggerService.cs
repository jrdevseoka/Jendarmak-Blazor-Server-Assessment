using Assembly.Site.Data.Services.Interfaces;
using NLog;

namespace Assembly.Site.Data.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly NLog.ILogger Logger = LogManager.GetCurrentClassLogger();
        public void Error(string message, Exception exception)
        {
            Logger.Error(exception, message);
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }
    }
}