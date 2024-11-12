using Asteroids.Code.Gameplay.Services.AsteroidFactory;
using Asteroids.Code.Gameplay.Services.AsteroidsSpawner;
using Asteroids.Code.Gameplay.Services.Boundaries;
using Asteroids.Code.Gameplay.Services.BulletFactory;
using Asteroids.Code.Gameplay.Services.Camera;
using Asteroids.Code.Gameplay.Services.CoordinateWrapper;
using Asteroids.Code.Gameplay.Services.EnginePowerService;
using Asteroids.Code.Gameplay.Services.PlayerFactory;
using Asteroids.Code.Infrastructure.GameplayStates;
using Asteroids.Code.Services.Input;
using Asteroids.Code.Services.RandomService;
using Asteroids.Code.Tools.StateMachine;
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
            builder.Register<IAsteroidFactory, PooledAsteroidFactory>(Lifetime.Singleton);
            builder.Register<IAsteroidSpawner, RandomAsteroidSpawner>(Lifetime.Singleton);
            builder.Register<IBoundaries, ScreenBoundaries>(Lifetime.Singleton);
            builder.Register<ICoordinateWrapper, CoordinateWrapper>(Lifetime.Singleton);
            builder.Register<IEnginePowerService, EnginePowerService>(Lifetime.Singleton);

            builder.Register<GameplayInitializationState>(Lifetime.Singleton);
            builder.Register<GameplayStartingState>(Lifetime.Singleton);
            builder.Register<GameLoopState>(Lifetime.Singleton);
            builder.Register<StateFactory>(Lifetime.Singleton);
            builder.Register<GameplayStateMachine>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameplayStartup>();
        }
    }
}