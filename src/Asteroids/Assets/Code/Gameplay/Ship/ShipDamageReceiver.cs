using Asteroids.Code.Gameplay.Damage;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Ship
{
    public sealed class ShipDamageReceiver : MonoBehaviour, IDamageable
    {
        [SerializeField] private ShipBehaviour _ship;

        public void TakeDamage(DamageType damageType, Vector2 attackDirection) => _ship.DecreaseHealth(1);
    }
}