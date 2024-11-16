using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Ui.Factory
{
    public interface IUIFactory
    {
        UniTask<PlayerUI> CreateHud();
    }
}