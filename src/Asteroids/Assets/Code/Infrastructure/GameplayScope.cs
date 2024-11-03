using Asteroids.Code.Infrastructure.GameplayStates;
using Asteroids.Code.Services.Input;
using Asteroids.Code.Services.RandomService;
using Asteroids.Code.Tools.StateMachine;
using VContainer;
using VContainer.Unity;

namespace Asteroids.Code.Infrastructure
{
    public sealed class GameplayScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<IInputService, InputService>(Lifetime.Singleton);
            builder.Register<IRandomService, UnityRandomService>(Lifetime.Singleton);

            builder.Register<GameplayInitializationState>(Lifetime.Singleton);
            builder.Register<GameLoopState>(Lifetime.Singleton);
            builder.Register<StateFactory>(Lifetime.Singleton);
            builder.Register<GameplayStateMachine>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameplayStartup>();
        }
    }
}