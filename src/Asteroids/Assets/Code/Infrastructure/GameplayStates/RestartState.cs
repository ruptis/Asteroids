using Asteroids.Code.Gameplay.Services.AsteroidsHolder;
using Asteroids.Code.Gameplay.Services.PointsSystem;
using Asteroids.Code.Services.LogService;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class RestartState : IState
    {
        private readonly ILogService _logService;
        private readonly IAsteroidsHolder _asteroidsHolder;
        private readonly GameplayStateMachine _gameplayStateMachine;
        private readonly IPointsSystem _pointsSystem;

        public RestartState(ILogService logService, GameplayStateMachine gameplayStateMachine,
            IAsteroidsHolder asteroidsHolder, IPointsSystem pointsSystem)
        {
            _logService = logService;
            _gameplayStateMachine = gameplayStateMachine;
            _asteroidsHolder = asteroidsHolder;
            _pointsSystem = pointsSystem;
        }

        public UniTask Exit() => default;

        public UniTask Enter()
        {
            _logService.Log("Restarting game");

            _asteroidsHolder.DestroyAllAsteroids();
            _pointsSystem.ResetPoints();

            _gameplayStateMachine.Enter<GameplayStartingState>().Forget();
            return default;
        }
    }
}