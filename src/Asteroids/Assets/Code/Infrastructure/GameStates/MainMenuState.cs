using Asteroids.Code.Services.SceneManagement;
using Asteroids.Code.Tools.StateMachine;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Infrastructure.GameStates
{
    public sealed class MainMenuState : IState
    {
        private readonly ISceneLoader _sceneLoader;

        public MainMenuState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public UniTask Exit() => default;

        public async UniTask Enter()
        {
            await _sceneLoader.Load("MainMenuScene");
        }
    }
}