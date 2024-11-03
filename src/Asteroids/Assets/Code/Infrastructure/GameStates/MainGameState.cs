using Asteroids.Code.Services.SceneManagement;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameStates
{
    public sealed class MainGameState : IState
    {
        private readonly ISceneLoader _sceneLoader;

        public MainGameState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            await _sceneLoader.Load("MainScene");
        }
    }
}