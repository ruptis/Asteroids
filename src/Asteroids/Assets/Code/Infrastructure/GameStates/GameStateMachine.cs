using Asteroids.Code.Services.LogService;
using Asteroids.Code.Tools.StateMachine;

namespace Asteroids.Code.Infrastructure.GameStates
{
    public sealed class GameStateMachine : StateMachine
    {
        public GameStateMachine(StateFactory stateFactory, ILogService logService) : base(stateFactory, logService)
        {
        }
    }
}