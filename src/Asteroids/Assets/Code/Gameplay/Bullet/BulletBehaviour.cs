using System;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Bullet
{
    public sealed class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private LinearMovement _movement;

        private float _lifetime = 0.5f;

        public event Action Destroyed;
        
        public void SetLifetime(float lifetime) => _lifetime = lifetime;

        public void Launch(Vector2 velocity)
        {
            transform.up = velocity.normalized;
            _movement.Move(velocity);
        }
        
        private void Update()
        {
            _lifetime -= Time.deltaTime;
            if (_lifetime <= 0) 
                Destroy();
        }

        private void Destroy() => Destroyed?.Invoke();
    }
}