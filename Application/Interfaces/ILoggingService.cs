namespace Application.Interfaces
{
    public interface ILoggingService
    {
        Task LogErrorAsync(Exception ex, string message = null);
        Task LogInfoAsync(string message);
    }
}
