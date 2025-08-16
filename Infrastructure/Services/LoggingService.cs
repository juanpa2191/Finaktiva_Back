using Application.Interfaces;

namespace Infrastructure.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly string _logFilePath;

        public LoggingService()
        {
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");
        }

        public async Task LogErrorAsync(Exception ex, string message = null)
        {
            var logMessage = $"[ERROR] {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {message} - {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}";
            await File.AppendAllTextAsync(_logFilePath, logMessage);
        }

        public async Task LogInfoAsync(string message)
        {
            var logMessage = $"[INFO] {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
            await File.AppendAllTextAsync(_logFilePath, logMessage);
        }
    }
}
