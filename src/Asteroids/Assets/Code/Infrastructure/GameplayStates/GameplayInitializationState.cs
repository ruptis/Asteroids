using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameplayInitializationState : IState
    {
        private readonly GameplayStateMachine _gameplayStateMachine;

        public GameplayInitializationState(GameplayStateMachine gameplayStateMachine)
        {
            _gameplayStateMachine = gameplayStateMachine;
        }

        public UniTask Exit() => default;

        public UniTask Enter()
        {
            _gameplayStateMachine.Enter<GameLoopState>().Forget();
            
            return default;
        }
    }
}