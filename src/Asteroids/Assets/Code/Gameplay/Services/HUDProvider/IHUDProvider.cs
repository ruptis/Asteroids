using Asteroids.Code.Gameplay.Ship;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Gameplay.Services.HUDProvider
{
    public interface IHUDProvider
    {
        UniTask Initialize();

        void Show();

        void Hide();

        void SetHealth(IHealth health);
    }
}