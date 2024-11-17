using Asteroids.Code.Services.AssetManagement;
using Asteroids.Code.Services.ConfigService;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameStates
{
    public sealed class BootstrapGameState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IAssets _assets;
        private readonly IConfigs _configs;

        public BootstrapGameState(GameStateMachine stateMachine, IAssets assets, IConfigs configs)
        {
            _stateMachine = stateMachine;
            _assets = assets;
            _configs = configs;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            await _assets.Initialize();
            await _configs.Initialize();
            _stateMachine.Enter<MainMenuState>().Forget();
        }
    }
}