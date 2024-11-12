using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Asteroid;
using Asteroids.Code.Gameplay.Services.AsteroidFactory;
using Asteroids.Code.Gameplay.Services.PlayerFactory;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameplayStartingState : IState
    {
        private readonly GameplayStateMachine _gameplayStateMachine;
        private readonly IPlayerFactory _playerFactory;
        private readonly IAsteroidFactory _asteroidsFactory;

        public GameplayStartingState(GameplayStateMachine gameplayStateMachine, IPlayerFactory playerFactory,
            IAsteroidFactory asteroidsFactory)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _playerFactory = playerFactory;
            _asteroidsFactory = asteroidsFactory;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            await _playerFactory.CreatePlayer();

            for (var i = 0; i < 3; i++)
            {
                Vector2 position = Random.insideUnitCircle * 10;
                AsteroidBehaviour asteroid = _asteroidsFactory.CreateAsteroid((AsteroidType)i, position);
                asteroid.Launch(-position.normalized);
            }

            _gameplayStateMachine.Enter<GameLoopState>().Forget();
        }
    }
}