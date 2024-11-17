using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Ui
{
    public interface IPopUpService
    {
        UniTask<GameOverPopup.Result> ShowGameOverPopup();

        void HideGameOverPopup();
    }
}