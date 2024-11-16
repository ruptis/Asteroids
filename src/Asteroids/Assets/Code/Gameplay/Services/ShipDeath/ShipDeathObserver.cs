using System;
using Asteroids.Code.Gameplay.Ship;
using Asteroids.Code.Infrastructure.GameplayStates;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Gameplay.Services.ShipDeath
{
    public sealed class ShipDeathObserver : IShipDeathObserver, IDisposable
    {
        private readonly GameplayStateMachine _gameplayStateMachine;
        private IHealth _playerHealth;

        public ShipDeathObserver(GameplayStateMachine gameplayStateMachine)
        {
            _gameplayStateMachine = gameplayStateMachine;
        }

        public void ObserveDeath(IHealth health)
        {
            _playerHealth = health;
            _playerHealth.Death += OnPlayerDeath;
        }
        
        private void OnPlayerDeath() => _gameplayStateMachine.Enter<GameOverState>().Forget();

        public void Dispose() => _playerHealth.Death -= OnPlayerDeath;
    }
}