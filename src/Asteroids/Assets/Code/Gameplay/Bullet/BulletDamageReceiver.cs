using Asteroids.Code.Gameplay.Damage;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Bullet
{
    public sealed class BulletDamageReceiver : MonoBehaviour, IDamageable
    {
        [SerializeField] private BulletBehaviour _bulletBehaviour;

        public void TakeDamage(DamageType damageType, Vector2 attackDirection) => _bulletBehaviour.Destroy();
    }
}