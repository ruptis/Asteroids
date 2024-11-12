namespace Asteroids.Code.Services.RandomService
{
    public interface IRandomService
    {
        float GetRandom(float min, float max);
        int GetRandom(int min, int max);
        
        T GetRandomEnum<T>(bool excludeFirstValue = true);
    }
}