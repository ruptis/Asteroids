using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.EnginePowerService
{
    public sealed class EnginePowerService : IEnginePowerService
    {
        private readonly float _maxMovementSpeed;
        private readonly float _maxAngularSpeed;

        public EnginePowerService()
        {
            _maxMovementSpeed = 5;
            _maxAngularSpeed = 180;
        }

        public EnginePowers CalculateEnginePowers(Vector2 velocity, float angularVelocity)
        {
            var speed = velocity.magnitude;
            var angularSpeed = Mathf.Abs(angularVelocity);
            
            var mainEnginePower = Mathf.Clamp01(speed / _maxMovementSpeed);
            
            var leftEnginePower = Mathf.Clamp01(mainEnginePower + angularSpeed / _maxAngularSpeed);
            var rightEnginePower = Mathf.Clamp01(mainEnginePower - angularSpeed / _maxAngularSpeed);
            
            return new EnginePowers
            {
                MainEnginePower = mainEnginePower,
                LeftEnginePower = leftEnginePower,
                RightEnginePower = rightEnginePower
            };
        }
    }
}