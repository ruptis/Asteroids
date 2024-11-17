using Asteroids.Code.Gameplay.Services.AsteroidsDeaths;
using Asteroids.Code.Gameplay.Services.AsteroidsSpawner;
using Asteroids.Code.Gameplay.Services.HUDProvider;
using Asteroids.Code.Gameplay.Services.PlayerFactory;
using Asteroids.Code.Gameplay.Services.ShipDeath;
using Asteroids.Code.Gameplay.Ship;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameplayStartingState : IState
    {
        private readonly GameplayStateMachine _gameplayStateMachine;
        private readonly IPlayerFactory _playerFactory;
        private readonly IAsteroidSpawner _asteroidSpawner;
        private readonly IHUDProvider _hudProvider;
        private readonly IShipDeathObserver _shipDeathObserver;
        private readonly IAsteroidDeathObserver _asteroidDeathObserver;

        public GameplayStartingState(GameplayStateMachine gameplayStateMachine, IPlayerFactory playerFactory,
            IAsteroidSpawner asteroidSpawner, IHUDProvider hudProvider, 
            IShipDeathObserver shipDeathObserver, IAsteroidDeathObserver asteroidDeathObserver)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _playerFactory = playerFactory;
            _asteroidSpawner = asteroidSpawner;
            _hudProvider = hudProvider;
            _shipDeathObserver = shipDeathObserver;
            _asteroidDeathObserver = asteroidDeathObserver;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            ShipBehaviour player = await _playerFactory.CreatePlayer();

            _hudProvider.SetHealth(player.Health);
            _shipDeathObserver.ObserveDeath(player);
            _asteroidDeathObserver.StartObserving();

            _asteroidSpawner.SpawnAllAsteroids();

            _gameplayStateMachine.Enter<GameLoopState>().Forget();
        }
    }
}