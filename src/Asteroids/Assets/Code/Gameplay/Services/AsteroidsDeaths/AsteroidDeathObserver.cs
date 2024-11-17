using System;
using Asteroids.Code.Gameplay.Asteroid;
using Asteroids.Code.Gameplay.Services.AsteroidsHolder;
using Asteroids.Code.Gameplay.Services.AsteroidsSpawner;
using Asteroids.Code.Gameplay.Services.PointsSystem;
using VContainer.Unity;

namespace Asteroids.Code.Gameplay.Services.AsteroidsDeaths
{
    public class AsteroidDeathObserver : IInitializable, IDisposable
    {
        private readonly IAsteroidsHolder _holder;
        private readonly IAsteroidSpawner _spawner;
        private readonly IPointsSystem _points;

        public AsteroidDeathObserver(IAsteroidsHolder holder, IAsteroidSpawner spawner, IPointsSystem points)
        {
            _holder = holder;
            _spawner = spawner;
            _points = points;
        }

        public void Initialize()
        {
            _holder.AsteroidDestroyed += OnAsteroidDestroyed;
        }

        public void Dispose()
        {
            _holder.AsteroidDestroyed -= OnAsteroidDestroyed;
        }

        private void OnAsteroidDestroyed(AsteroidBehaviour asteroid)
        {
            _spawner.SpawnAsteroid();
            _points.AddPointsForAsteroidDestroyed();
        }
    }
}