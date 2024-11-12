using Asteroids.Code.Gameplay.Services.AsteroidFactory;
using Asteroids.Code.Gameplay.Services.BulletFactory;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameplayInitializationState : IState
    {
        private readonly GameplayStateMachine _gameplayStateMachine;
        private readonly IBulletFactory _bulletFactory;
        private readonly IAsteroidFactory _asteroidsFactory;

        public GameplayInitializationState(GameplayStateMachine gameplayStateMachine, IBulletFactory bulletFactory,
            IAsteroidFactory asteroidsFactory)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _bulletFactory = bulletFactory;
            _asteroidsFactory = asteroidsFactory;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            await _bulletFactory.Initialize();
            await _asteroidsFactory.Initialize();

            _gameplayStateMachine.Enter<GameplayStartingState>().Forget();
        }
    }
}