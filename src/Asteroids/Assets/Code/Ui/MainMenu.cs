using Asteroids.Code.Infrastructure.GameStates;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Asteroids.Code.Ui
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        
        private GameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayClick);
            _exitButton.onClick.AddListener(Application.Quit);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(OnPlayClick);
            _exitButton.onClick.RemoveListener(Application.Quit);
        }

        private void OnPlayClick() => _gameStateMachine.Enter<MainGameState>().Forget();
    }
}