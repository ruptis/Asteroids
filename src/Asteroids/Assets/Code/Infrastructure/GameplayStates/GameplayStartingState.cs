﻿using Asteroids.Code.Gameplay.Services.AsteroidsSpawner;
using Asteroids.Code.Gameplay.Services.HUDProvider;
using Asteroids.Code.Gameplay.Services.PlayerFactory;
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

        public GameplayStartingState(GameplayStateMachine gameplayStateMachine, IPlayerFactory playerFactory,
            IAsteroidSpawner asteroidSpawner, IHUDProvider hudProvider)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _playerFactory = playerFactory;
            _asteroidSpawner = asteroidSpawner;
            _hudProvider = hudProvider;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            ShipBehaviour player = await _playerFactory.CreatePlayer();

            _hudProvider.SetHealth(player.Health);

            for (var i = 0; i < 10; i++)
            {
                _asteroidSpawner.SpawnAsteroid();
            }

            _gameplayStateMachine.Enter<GameLoopState>().Forget();
        }
    }
}