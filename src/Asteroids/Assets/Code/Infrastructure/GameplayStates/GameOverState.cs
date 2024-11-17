using System;
using Asteroids.Code.Services.LogService;
using Asteroids.Code.Tools.StateMachine;
using Asteroids.Code.Ui;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameOverState : IState
    {
        private readonly ILogService _logService;
        private readonly IPopUpService _popUpService;
        private readonly GameplayStateMachine _gameplayStateMachine;

        public GameOverState(ILogService logService, IPopUpService popUpService, GameplayStateMachine gameplayStateMachine)
        {
            _logService = logService;
            _popUpService = popUpService;
            _gameplayStateMachine = gameplayStateMachine;
        }

        public UniTask Exit()
        {
            _popUpService.HideGameOverPopup();
            return default;
        }

        public async UniTask Enter()
        {
            _logService.Log("Game Over");
            
            GameOverPopup.Result result = await _popUpService.ShowGameOverPopup();
            switch (result)
            {
                case GameOverPopup.Result.Restart:
                    _gameplayStateMachine.Enter<RestartState>().Forget();
                    break;
                case GameOverPopup.Result.Exit:
                    _gameplayStateMachine.Enter<ExitState>().Forget();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}