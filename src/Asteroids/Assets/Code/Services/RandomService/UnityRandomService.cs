namespace Asteroids.Code.Services.RandomService
{
    public sealed class UnityRandomService : IRandomService
    {
        public float GetRandom(float min, float max) => UnityEngine.Random.Range(min, max);

        public int GetRandom(int min, int max) => UnityEngine.Random.Range(min, max);
    }
}