using Asteroids.Code.Infrastructure.GameStates;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Asteroids.Code.Infrastructure
{
    public sealed class GameStartup : IStartable
    {
        private readonly GameStateMachine _stateMachine;

        public GameStartup(GameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        public void Start() => _stateMachine.Enter<BootstrapGameState>().Forget();
    }
}