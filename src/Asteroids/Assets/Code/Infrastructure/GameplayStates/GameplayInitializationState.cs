using Asteroids.Code.Gameplay.Services.BulletFactory;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameplayInitializationState : IState
    {
        private readonly GameplayStateMachine _gameplayStateMachine;
        private readonly IBulletFactory _bulletFactory;

        public GameplayInitializationState(GameplayStateMachine gameplayStateMachine, IBulletFactory bulletFactory)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _bulletFactory = bulletFactory;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            await _bulletFactory.Initialize();
            
            _gameplayStateMachine.Enter<GameplayStartingState>().Forget();
        }
    }
}