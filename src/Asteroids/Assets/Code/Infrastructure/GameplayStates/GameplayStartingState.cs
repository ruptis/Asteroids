using Asteroids.Code.Gameplay.Services.PlayerFactory;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameplayStartingState : IState
    {
        private readonly GameplayStateMachine _gameplayStateMachine;
        private readonly IPlayerFactory _playerFactory;
        
        public GameplayStartingState(GameplayStateMachine gameplayStateMachine, IPlayerFactory playerFactory)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _playerFactory = playerFactory;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            await _playerFactory.CreatePlayer();

            _gameplayStateMachine.Enter<GameLoopState>().Forget();
        }
    }
}