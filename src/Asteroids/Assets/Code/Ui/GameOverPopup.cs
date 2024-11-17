using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Code.Ui
{
    public class GameOverPopup : MonoBehaviour
    {
        public enum Result
        {
            Restart,
            Exit
        }

        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _message;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        public void SetValues(string title, string message)
        {
            _title.text = title;
            _message.text = message;
        }

        public async UniTask<Result> Show()
        {
            _restartButton.Select();
            int index = await UniTask.WhenAny(_restartButton.OnClickAsync(), _exitButton.OnClickAsync());
            return index == 0 ? Result.Restart : Result.Exit;
        }
    }
}