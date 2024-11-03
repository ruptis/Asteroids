using Asteroids.Code.Services.Input;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameLoopState : IState
    {
        private readonly IInputService _inputService;

        public GameLoopState(IInputService inputService)
        {
            _inputService = inputService;
        }

        public UniTask Exit()
        {
            _inputService.Disable();
            return default;
        }

        public UniTask Enter()
        {
            _inputService.Enable();
            return default;
        }
    }
}