using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Asteroid;
using Asteroids.Code.Gameplay.Services.AsteroidFactory;
using Asteroids.Code.Gameplay.Services.AsteroidsHolder;
using Asteroids.Code.Gameplay.Services.Boundaries;
using Asteroids.Code.Services.ConfigService;
using Asteroids.Code.Services.RandomService;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.AsteroidsSpawner
{
    public sealed class RandomAsteroidSpawner : IAsteroidSpawner
    {
        private const float MaxDirectionAngleFromCenter = 20f;
        private readonly IAsteroidFactory _asteroidFactory;
        private readonly IRandomService _randomService;

        private readonly float _perimeter;
        private readonly Vector2 _center;
        private readonly Vector2[] _corners = new Vector2[4];
        private readonly IAsteroidsHolder _asteroidsHolder;
        private readonly GameConfig _gameConfig;

        public RandomAsteroidSpawner(IBoundaries boundaries, IAsteroidFactory asteroidFactory,
            IRandomService randomService, IAsteroidsHolder asteroidsHolder, IConfigs configs)
        {
            _asteroidFactory = asteroidFactory;
            _randomService = randomService;
            _asteroidsHolder = asteroidsHolder;
            _gameConfig = configs.GetGameConfig();
            var width = boundaries.Max.x - boundaries.Min.x;
            var height = boundaries.Max.y - boundaries.Min.y;
            _perimeter = 2 * (width + height);
            _center = boundaries.Center;

            _corners[0] = boundaries.Min;
            _corners[1] = new Vector2(boundaries.Max.x, boundaries.Min.y);
            _corners[2] = boundaries.Max;
            _corners[3] = new Vector2(boundaries.Min.x, boundaries.Max.y);
        }

        public void SpawnAsteroid()
        {
            if (_asteroidsHolder.AsteroidsCount >= _gameConfig.AsteroidsCount)
                return;

            var spawnDistance = _randomService.GetRandom(0, _perimeter);

            Vector2 spawnPosition = Vector2.zero;
            for (var i = 0; i < _corners.Length; i++)
            {
                Vector2 corner = _corners[i];
                Vector2 nextCorner = _corners[(i + 1) % _corners.Length];

                var distanceToNextCorner = Vector2.Distance(corner, nextCorner);
                if (spawnDistance < distanceToNextCorner)
                {
                    spawnPosition = corner + (nextCorner - corner).normalized * spawnDistance;
                    break;
                }

                spawnDistance -= distanceToNextCorner;
            }

            var randomAngle = _randomService.GetRandom(-MaxDirectionAngleFromCenter, MaxDirectionAngleFromCenter);
            Vector2 directionToCenter = (_center - spawnPosition).normalized;
            Vector2 direction = Quaternion.Euler(0, 0, randomAngle) * directionToCenter;

            var asteroidType = _randomService.GetRandomEnum<AsteroidType>();
            AsteroidBehaviour asteroid = _asteroidFactory.CreateAsteroid(asteroidType, spawnPosition);
            asteroid.Launch(direction);
        }

        public void SpawnAllAsteroids()
        {
            for (var i = 0; i < _gameConfig.AsteroidsCount; i++)
                SpawnAsteroid();
        }
    }
}