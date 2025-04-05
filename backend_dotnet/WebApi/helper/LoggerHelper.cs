namespace WebApi.helper
{
    public class LoggerHelper<T>(ILogger<T> logger)
    {
        private readonly ILogger<T> _logger = logger;

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message, Exception? ex = null)
        {
            _logger.LogError(ex, message);
        }

        public void LogDebug(string message)
        {
            _logger.LogDebug(message);
        }

        public void LogTrace(string message)
        {
            _logger.LogTrace(message);
        }

        public void LogCritical(string message, Exception? ex = null)
        {
            _logger.LogCritical(ex, message);
        }

        public void Log(string message, LogLevel level, Exception? ex = null)
        {
            _logger.Log(level, ex, message);
        }
    }
}