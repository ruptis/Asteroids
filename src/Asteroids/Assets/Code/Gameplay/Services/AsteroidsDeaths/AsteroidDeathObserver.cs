using System;
using Asteroids.Code.Gameplay.Asteroid;
using Asteroids.Code.Gameplay.Services.AsteroidsHolder;
using Asteroids.Code.Gameplay.Services.AsteroidsSpawner;
using Asteroids.Code.Gameplay.Services.PointsSystem;
using Asteroids.Code.Gameplay.Services.Sound;

namespace Asteroids.Code.Gameplay.Services.AsteroidsDeaths
{
    public class AsteroidDeathObserver : IDisposable, IAsteroidDeathObserver
    {
        private readonly IAsteroidsHolder _holder;
        private readonly IAsteroidSpawner _spawner;
        private readonly IPointsSystem _points;
        private readonly ISoundPlayer _soundPlayer;

        public AsteroidDeathObserver(IAsteroidsHolder holder, IAsteroidSpawner spawner, IPointsSystem points, ISoundPlayer soundPlayer)
        {
            _holder = holder;
            _spawner = spawner;
            _points = points;
            _soundPlayer = soundPlayer;
        }

        public void StartObserving()
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
            _soundPlayer.PlaySound(SoundType.Explosion);
        }
    }
}