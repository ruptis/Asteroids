using System;

namespace Asteroids.Code.Gameplay.Ship
{
    public sealed class ShipHealth : IHealth
    {
        public ShipHealth(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public int CurrentHealth { get; private set; }

        public int MaxHealth { get; }

        public event Action<int> HealthChanged;

        public event Action Death;

        public void DecreaseHealth(int amount)
        {
            CurrentHealth -= Math.Clamp(amount, 0, CurrentHealth);

            HealthChanged?.Invoke(CurrentHealth);

            if (CurrentHealth <= 0)
                Death?.Invoke();
        }
    }
}