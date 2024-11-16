using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Asteroid;
using Asteroids.Code.Gameplay.Services.AsteroidFactory;
using Asteroids.Code.Gameplay.Services.AsteroidsHolder;
using Asteroids.Code.Services.RandomService;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.AsteroidDestructor
{
    public sealed class AsteroidDestructor : IAsteroidDestructor
    {
        private readonly IAsteroidFactory _asteroidFactory;
        private readonly IRandomService _randomService;
        private readonly IAsteroidsHolder _asteroidsHolder;

        public AsteroidDestructor(IAsteroidFactory asteroidFactory, IRandomService randomService,
            IAsteroidsHolder asteroidsHolder)
        {
            _asteroidFactory = asteroidFactory;
            _randomService = randomService;
            _asteroidsHolder = asteroidsHolder;
        }

        public void DestroyAsteroid(Vector2 position, Vector2 direction, AsteroidPartConfig[] parts)
        {
            for (var index = 0; index < parts.Length && !_asteroidsHolder.IsFull; index++)
            {
                AsteroidPartConfig part = parts[index];
                var angle = _randomService.GetRandom(part.MinExitAngle, part.MaxExitAngle);
                Vector2 partDirection = Quaternion.Euler(0, 0, angle) * direction;
                Vector2 partPosition = position + partDirection * part.PositionOffset;

                AsteroidBehaviour asteroidPart = _asteroidFactory.CreateAsteroid(part.Type, partPosition);

                asteroidPart.Launch(partDirection);
            }
        }
    }
}