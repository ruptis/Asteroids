using System;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Asteroid
{
    public sealed class AsteroidBehaviour : MonoBehaviour
    {
        [SerializeField] private LinearMovement _movement;
        [SerializeField] private Rotation _rotation;

        private float _movementSpeed;
        private float _rotationSpeed;
        private bool _isClockwise;

        public event Action Destroyed;
        
        public void Configure(float movementSpeed, float rotationSpeed, bool isClockwise)
        {
            _movementSpeed = movementSpeed;
            _rotationSpeed = rotationSpeed;
            _isClockwise = isClockwise;
        }

        public void Launch(Vector2 direction)
        {
            _movement.Move(direction.normalized * _movementSpeed);
            _rotation.Rotate(_rotationSpeed, _isClockwise);
        }

        public void Destroy()
        {
            Destroyed?.Invoke();
        }
    }
}