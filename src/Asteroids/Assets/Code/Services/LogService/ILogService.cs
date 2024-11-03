namespace Asteroids.Code.Services.LogService
{
    public interface ILogService
    {
        void Log(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}