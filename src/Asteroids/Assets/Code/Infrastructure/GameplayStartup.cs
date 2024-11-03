using Asteroids.Code.Infrastructure.GameplayStates;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Asteroids.Code.Infrastructure
{
    public sealed class GameplayStartup : IStartable
    {
        private readonly GameplayStateMachine _gameplayStateMachine;

        public GameplayStartup(GameplayStateMachine gameplayStateMachine) => 
            _gameplayStateMachine = gameplayStateMachine;

        public void Start() => _gameplayStateMachine.Enter<GameplayInitializationState>().Forget();
    }
}