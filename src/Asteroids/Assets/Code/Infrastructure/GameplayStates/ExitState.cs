using Asteroids.Code.Infrastructure.GameStates;
using Asteroids.Code.Services.LogService;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class ExitState : IState
    {
        private readonly ILogService _logService;
        private readonly GameStateMachine _gameStateMachine;

        public ExitState(ILogService logService, GameStateMachine gameStateMachine)
        {
            _logService = logService;
            _gameStateMachine = gameStateMachine;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            _logService.Log("Exiting game");
            await _gameStateMachine.Enter<BootstrapGameState>();
        }
    }
}