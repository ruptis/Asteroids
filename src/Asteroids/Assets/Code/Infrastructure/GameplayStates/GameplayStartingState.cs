using Asteroids.Code.Gameplay.Services.AsteroidsSpawner;
using Asteroids.Code.Gameplay.Services.PlayerFactory;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameplayStartingState : IState
    {
        private readonly GameplayStateMachine _gameplayStateMachine;
        private readonly IPlayerFactory _playerFactory;
        private readonly IAsteroidSpawner _asteroidSpawner;

        public GameplayStartingState(GameplayStateMachine gameplayStateMachine, IPlayerFactory playerFactory,
            IAsteroidSpawner asteroidSpawner)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _playerFactory = playerFactory;
            _asteroidSpawner = asteroidSpawner;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            await _playerFactory.CreatePlayer();

            for (var i = 0; i < 10; i++)
            {
                _asteroidSpawner.SpawnAsteroid();
            }

            _gameplayStateMachine.Enter<GameLoopState>().Forget();
        }
    }
}