using Asteroids.Code.Services.LogService;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameOverState : IState
    {
        private readonly ILogService _logService;

        public GameOverState(ILogService logService)
        {
            _logService = logService;
        }

        public UniTask Exit()
        {
            return default;
        }

        public UniTask Enter()
        {
            _logService.Log("Game Over");

            return default;
        }
    }
}