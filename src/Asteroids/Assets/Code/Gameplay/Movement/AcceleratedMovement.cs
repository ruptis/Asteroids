using UnityEngine;

namespace Asteroids.Code.Gameplay.Movement
{
    public sealed class AcceleratedMovement : MonoBehaviour
    {
        private float _maxSpeed;
        private float _rotationSpeed;
        private float _accelerationTime;
        private float _decelerationTime;

        private Vector2 _velocity;
        private float _desiredSpeed;
        private float _desiredRotation;
        
        public Vector2 Velocity => _velocity;
        public float AngularVelocity => _desiredRotation;
        public bool IsAccelerating { get; private set; }

        public void Move(Vector2 input)
        {
            _desiredSpeed = Mathf.Max(input.y, 0) * _maxSpeed;
            _desiredRotation = -input.x * _rotationSpeed;
        }
        
        public void Configure(float maxSpeed, float rotationSpeed, float accelerationTime, float decelerationTime)
        {
            _maxSpeed = maxSpeed;
            _rotationSpeed = rotationSpeed;
            _accelerationTime = accelerationTime;
            _decelerationTime = decelerationTime;
        }

        private void Update()
        {
            if (_desiredSpeed != 0)
                AccelerateMovement();
            else
                DecelerateMovement();

            transform.position += (Vector3)_velocity * Time.deltaTime;
            transform.Rotate(Vector3.forward, _desiredRotation * Time.deltaTime);
            _desiredSpeed = 0;
            _desiredRotation = 0;
        }

        private void AccelerateMovement()
        {
            _velocity = Vector2.Lerp(_velocity, transform.up * _desiredSpeed, Time.deltaTime / _accelerationTime);
            IsAccelerating = true;
        }

        private void DecelerateMovement()
        {
            _velocity = Vector2.Lerp(_velocity, Vector2.zero, Time.deltaTime / _decelerationTime);
            IsAccelerating = false;
        }
    }
}