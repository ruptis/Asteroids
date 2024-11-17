using Asteroids.Code.Infrastructure.GameStates;
using Asteroids.Code.Services.AssetManagement;
using Asteroids.Code.Services.ConfigService;
using Asteroids.Code.Services.LogService;
using Asteroids.Code.Services.SceneManagement;
using Asteroids.Code.Tools.StateMachine;
using VContainer;
using VContainer.Unity;

namespace Asteroids.Code.Infrastructure
{
    public sealed class BootstrapScope : LifetimeScope
    {
        protected override void Awake()
        {
            DontDestroyOnLoad(this);
            base.Awake();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<ILogService, UnityLogService>(Lifetime.Singleton);
            builder.Register<IAssets, AssetsProvider>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IConfigs, ConfigsProvider>(Lifetime.Singleton);
            
            builder.Register<BootstrapGameState>(Lifetime.Singleton);
            builder.Register<MainMenuState>(Lifetime.Singleton);
            builder.Register<MainGameState>(Lifetime.Singleton);
            builder.Register<StateFactory>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameStartup>();
        }
    }
}