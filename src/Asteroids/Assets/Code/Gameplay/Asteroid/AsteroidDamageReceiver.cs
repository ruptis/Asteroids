using System;
using Asteroids.Code.Gameplay.Damage;
using Asteroids.Code.Gameplay.Services.AsteroidsSpawner;
using UnityEngine;
using VContainer;

namespace Asteroids.Code.Gameplay.Asteroid
{
    public sealed class AsteroidDamageReceiver : MonoBehaviour, IDamageable
    {
        [SerializeField] private AsteroidBehaviour _asteroid;

        private IAsteroidSpawner _asteroidSpawner;

        [Inject]
        public void Construct(IAsteroidSpawner asteroidSpawner)
        {
            _asteroidSpawner = asteroidSpawner;
        }

        public void TakeDamage(DamageType damageType, Vector2 attackDirection)
        {
            if (damageType == DamageType.Bullet)
                Explode();
            else
                ChangeDirection(attackDirection);
        }

        private void Explode()
        {
            _asteroid.Destroy();

            _asteroidSpawner.SpawnAsteroid();
        }

        private void ChangeDirection(Vector2 attackDirection)
        {
            _asteroid.Launch(attackDirection);
        }
    }
}