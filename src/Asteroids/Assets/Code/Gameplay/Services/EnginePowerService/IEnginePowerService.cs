using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.EnginePowerService
{
    public interface IEnginePowerService
    {
        EnginePowers CalculateEnginePowers(Vector2 velocity, float angularVelocity);
    }
}