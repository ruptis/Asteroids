using Asteroids.Code.Gameplay.Services.AsteroidFactory;
using Asteroids.Code.Gameplay.Services.BulletFactory;
using Asteroids.Code.Gameplay.Services.HUDProvider;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameplayInitializationState : IState
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly IAsteroidFactory _asteroidFactory;
        private readonly IHUDProvider _hudProvider;
        private readonly GameplayStateMachine _gameplayStateMachine;

        public GameplayInitializationState(IBulletFactory bulletFactory, IAsteroidFactory asteroidFactory,
            GameplayStateMachine gameplayStateMachine, IHUDProvider hudProvider)
        {
            _asteroidFactory = asteroidFactory;
            _gameplayStateMachine = gameplayStateMachine;
            _hudProvider = hudProvider;
            _bulletFactory = bulletFactory;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            await _bulletFactory.Initialize();
            await _asteroidFactory.Initialize();
            await _hudProvider.Initialize();

            _gameplayStateMachine.Enter<GameplayStartingState>().Forget();
        }
    }
}