using System;
using Asteroids.Code.Gameplay.Movement;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Bullet
{
    public sealed class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private LinearMovement _movement;
        [SerializeField] private GameObject _explosionPrefab;

        private float _lifetime;

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
                Destroyed?.Invoke();
        }

        public void Destroy()
        {
            if (_explosionPrefab != null)
                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroyed?.Invoke();
        }
    }
}