using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Damage;
using Asteroids.Code.Gameplay.Services.AsteroidDestructor;
using UnityEngine;
using VContainer;

namespace Asteroids.Code.Gameplay.Asteroid
{
    public sealed class AsteroidDamageReceiver : MonoBehaviour, IDamageable
    {
        [SerializeField] private AsteroidBehaviour _asteroid;

        private IAsteroidDestructor _asteroidDestructor;
        private AsteroidPartConfig[] _parts;

        [Inject]
        public void Construct(IAsteroidDestructor asteroidDestructor)
        {
            _asteroidDestructor = asteroidDestructor;
        }

        public void SetParts(AsteroidPartConfig[] parts) => _parts = parts;

        public void TakeDamage(DamageType damageType, Vector2 attackDirection)
        {
            if (damageType == DamageType.Bullet)
                Explode(attackDirection);
            else
                ChangeDirection(attackDirection);
        }

        private void Explode(Vector2 attackDirection)
        {
            _asteroid.Destroy();
            
            _asteroidDestructor.DestroyAsteroid(transform.position, attackDirection, _parts);
        }

        private void ChangeDirection(Vector2 attackDirection)
        {
            _asteroid.Launch(attackDirection);
        }
    }
}