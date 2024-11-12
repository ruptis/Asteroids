using UnityEngine;

namespace Asteroids.Code.Gameplay.Damage
{
    public interface IDamageable
    {
        void TakeDamage(DamageType damageType, Vector2 attackDirection);
    }
}