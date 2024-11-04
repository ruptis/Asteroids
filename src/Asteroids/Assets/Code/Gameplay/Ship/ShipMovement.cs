using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroids.Code.Gameplay.Ship
{
    public sealed class ShipMovement : MonoBehaviour
    {
        public float MaxSpeed = 5;
        public float RotationSpeed = 180;
        public float AccelerationTime = 1;
        public float DecelerationTime = 1;

        private Vector2 _velocity;
        private float _desiredSpeed;
        private float _desiredRotation;
        
        public Vector2 Velocity => _velocity;
        public float AngularVelocity => _desiredRotation;
        public bool IsAccelerating { get; private set; }

        public void Move(Vector2 input)
        {
            _desiredSpeed = Mathf.Max(input.y, 0) * MaxSpeed;
            _desiredRotation = -input.x * RotationSpeed;
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
            _velocity = Vector2.Lerp(_velocity, transform.up * _desiredSpeed, Time.deltaTime / AccelerationTime);
            IsAccelerating = true;
        }

        private void DecelerateMovement()
        {
            _velocity = Vector2.Lerp(_velocity, Vector2.zero, Time.deltaTime / DecelerationTime);
            IsAccelerating = false;
        }
    }
}