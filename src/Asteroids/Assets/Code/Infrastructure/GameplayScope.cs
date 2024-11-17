using System;
using Asteroids.Code.Gameplay.Services.AsteroidDestructor;
using Asteroids.Code.Gameplay.Services.AsteroidFactory;
using Asteroids.Code.Gameplay.Services.AsteroidsDeaths;
using Asteroids.Code.Gameplay.Services.AsteroidsHolder;
using Asteroids.Code.Gameplay.Services.AsteroidsSpawner;
using Asteroids.Code.Gameplay.Services.Boundaries;
using Asteroids.Code.Gameplay.Services.BulletFactory;
using Asteroids.Code.Gameplay.Services.Camera;
using Asteroids.Code.Gameplay.Services.CoordinateWrapper;
using Asteroids.Code.Gameplay.Services.EnginePowerService;
using Asteroids.Code.Gameplay.Services.HUDProvider;
using Asteroids.Code.Gameplay.Services.PlayerFactory;
using Asteroids.Code.Gameplay.Services.PointsSystem;
using Asteroids.Code.Gameplay.Services.ShipDeath;
using Asteroids.Code.Gameplay.Services.Sound;
using Asteroids.Code.Infrastructure.GameplayStates;
using Asteroids.Code.Services.Input;
using Asteroids.Code.Services.RandomService;
using Asteroids.Code.Tools.StateMachine;
using Asteroids.Code.Ui;
using Asteroids.Code.Ui.Factory;
using Asteroids.Code.Ui.PopUps;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Asteroids.Code.Infrastructure
{
    public sealed class GameplayScope : LifetimeScope
    {
        [SerializeField] private Camera _camera;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<ICameraProvider, CameraProvider>(Lifetime.Singleton).WithParameter(_camera);
            builder.Register<IInputService, InputService>(Lifetime.Singleton);
            builder.Register<IRandomService, UnityRandomService>(Lifetime.Singleton);

            builder.Register<IPlayerFactory, PlayerFactory>(Lifetime.Singleton);
            builder.Register<IBulletFactory, PooledBulletFactory>(Lifetime.Singleton);

            builder.Register<IAsteroidsHolder, AsteroidsHolder>(Lifetime.Singleton);
            builder.Register<IAsteroidFactory, PooledAsteroidFactory>(Lifetime.Singleton);
            builder.Register<IAsteroidSpawner, RandomAsteroidSpawner>(Lifetime.Singleton);
            builder.Register<IAsteroidDestructor, AsteroidDestructor>(Lifetime.Singleton);

            builder.Register<IBoundaries, ScreenBoundaries>(Lifetime.Singleton);
            builder.Register<ICoordinateWrapper, CoordinateWrapper>(Lifetime.Singleton);
            builder.Register<IEnginePowerService, EnginePowerService>(Lifetime.Singleton);
            
            builder.Register<IShipDeathObserver, ShipDeathObserver>(Lifetime.Singleton).As<IDisposable>();
            builder.Register<IAsteroidDeathObserver, AsteroidDeathObserver>(Lifetime.Singleton).As<IDisposable>();
            builder.Register<IPointsSystem, PointsSystem>(Lifetime.Singleton);
            
            builder.Register<ISoundPlayer, SoundPlayer>(Lifetime.Singleton);

            builder.Register<IUIFactory, UIFactory>(Lifetime.Singleton);
            builder.Register<IPopUpService, PopUpService>(Lifetime.Singleton);
            builder.Register<IHUDProvider, HUDProvider>(Lifetime.Singleton);

            builder.Register<GameplayInitializationState>(Lifetime.Singleton);
            builder.Register<GameplayStartingState>(Lifetime.Singleton);
            builder.Register<GameLoopState>(Lifetime.Singleton);
            builder.Register<GameOverState>(Lifetime.Singleton);
            builder.Register<RestartState>(Lifetime.Singleton);
            builder.Register<ExitState>(Lifetime.Singleton);
            builder.Register<StateFactory>(Lifetime.Singleton);
            builder.Register<GameplayStateMachine>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameplayStartup>();
        }
    }
}