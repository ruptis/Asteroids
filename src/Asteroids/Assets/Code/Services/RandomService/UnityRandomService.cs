using System;
using Random = UnityEngine.Random;

namespace Asteroids.Code.Services.RandomService
{
    public sealed class UnityRandomService : IRandomService
    {
        public float GetRandom(float min, float max) => Random.Range(min, max);

        public int GetRandom(int min, int max) => Random.Range(min, max);

        public T GetRandomEnum<T>(bool excludeFirstValue = true)
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(GetRandom(excludeFirstValue ? 1 : 0, values.Length));
        }
    }
}