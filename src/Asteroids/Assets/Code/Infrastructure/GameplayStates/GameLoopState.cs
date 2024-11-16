using Asteroids.Code.Gameplay.Services.HUDProvider;
using Asteroids.Code.Services.Input;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameLoopState : IState
    {
        private readonly IInputService _inputService;
        private readonly IHUDProvider _hudProvider;

        public GameLoopState(IInputService inputService, IHUDProvider hudProvider)
        {
            _inputService = inputService;
            _hudProvider = hudProvider;
        }

        public UniTask Exit()
        {
            _inputService.Disable();
            _hudProvider.Hide();
            return default;
        }

        public UniTask Enter()
        {
            _hudProvider.Show();
            _inputService.Enable();
            return default;
        }
    }
}