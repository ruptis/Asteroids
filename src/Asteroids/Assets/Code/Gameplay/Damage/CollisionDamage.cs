using System;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Damage
{
    public sealed class CollisionDamage : MonoBehaviour
    {
        [SerializeField] private DamageType _damageType;
        
        public event Action DamageDealt;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damageType, CalculateAttackDirection(other));
                DamageDealt?.Invoke();
            }
        }

        private Vector2 CalculateAttackDirection(Collider2D other) =>
            (other.transform.position - transform.position).normalized;
    }
}