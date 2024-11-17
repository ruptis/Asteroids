using Asteroids.Code.Gameplay.Services.PointsSystem;
using Asteroids.Code.Gameplay.Ship;
using UnityEngine;
using VContainer;

namespace Asteroids.Code.Ui
{
    public sealed class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private HealthCounter _healthCounter;
        [SerializeField] private PointsCounter _pointsCounter;

        private IHealth _health;
        private IPointsSystem _pointsSystem;

        [Inject]
        public void Construct(IPointsSystem pointsSystem)
        {
            _pointsSystem = pointsSystem;
            _pointsSystem.PointsChanged += OnPointsChanged;
        }

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
            _pointsSystem.PointsChanged -= OnPointsChanged;
        }

        private void OnHealthChanged(int current) =>
            _healthCounter.SetValues(current, _health.MaxHealth);

        private void OnPointsChanged(int amount) =>
            _pointsCounter.SetPoints(amount);
    }
}