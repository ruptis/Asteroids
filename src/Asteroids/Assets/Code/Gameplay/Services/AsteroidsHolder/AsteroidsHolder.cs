using System;
using System.Collections.Generic;
using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Asteroid;
using Asteroids.Code.Services.ConfigService;

namespace Asteroids.Code.Gameplay.Services.AsteroidsHolder
{
    public sealed class AsteroidsHolder : IAsteroidsHolder
    {
        private readonly HashSet<AsteroidBehaviour> _asteroids = new();
        private readonly GameConfig _gameConfig;

        public AsteroidsHolder(IConfigs configs)
        {
            _gameConfig = configs.GetGameConfig();
        }

        public bool IsFull => _asteroids.Count >= _gameConfig.MaxAsteroidsCount;

        public int AsteroidsCount => _asteroids.Count;

        public event Action<AsteroidBehaviour> AsteroidDestroyed;

        public void AddAsteroid(AsteroidBehaviour asteroid) => _asteroids.Add(asteroid);

        public void RemoveAsteroid(AsteroidBehaviour asteroid)
        {
            if (!_asteroids.Contains(asteroid)) return;

            _asteroids.Remove(asteroid);
            AsteroidDestroyed?.Invoke(asteroid);
        }

        public void DestroyAllAsteroids()
        {
            var asteroids = new List<AsteroidBehaviour>(_asteroids);

            AsteroidDestroyed = null;
            
            foreach (AsteroidBehaviour asteroid in asteroids)
                asteroid.Destroy();
        }
    }
}