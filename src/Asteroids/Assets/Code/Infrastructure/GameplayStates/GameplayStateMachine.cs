using Asteroids.Code.Services.LogService;
using Asteroids.Code.Tools.StateMachine;

namespace Asteroids.Code.Infrastructure.GameplayStates
{
    public sealed class GameplayStateMachine : StateMachine
    {
        public GameplayStateMachine(StateFactory stateFactory, ILogService logService) : base(stateFactory, logService)
        {
        }
    }
}