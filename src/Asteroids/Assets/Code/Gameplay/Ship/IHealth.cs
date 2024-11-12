using System;

namespace Asteroids.Code.Gameplay.Ship
{
    public interface IHealth
    {
        int CurrentHealth { get; }
        int MaxHealth { get; }

        event Action<int> HealthChanged;
        event Action Death;
    }
}