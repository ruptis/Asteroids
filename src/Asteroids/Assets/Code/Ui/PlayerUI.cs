using Asteroids.Code.Gameplay.Ship;
using UnityEngine;

namespace Asteroids.Code.Ui
{
    public sealed class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private HealthCounter _healthCounter;

        private IHealth _health;

        public void SetHealth(IHealth health)
        {
            _health = health;
            _health.HealthChanged += OnHealthChanged;
            _healthCounter.SetValues(_health.CurrentHealth, _health.MaxHealth);
        }

        public void Show() => _canvas.enabled = true;

        public void Hide() => _canvas.enabled = false;

        private void OnDestroy()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int current) =>
            _healthCounter.SetValues(current, _health.MaxHealth);
    }
}