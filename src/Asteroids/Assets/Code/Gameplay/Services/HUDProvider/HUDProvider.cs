using Asteroids.Code.Gameplay.Ship;
using Asteroids.Code.Ui;
using Asteroids.Code.Ui.Factory;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Gameplay.Services.HUDProvider
{
    public sealed class HUDProvider : IHUDProvider
    {
        private readonly IUIFactory _uiFactory;

        private PlayerUI _playerUi;

        public HUDProvider(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public async UniTask Initialize()
        {
            _playerUi = await _uiFactory.CreateHud();
        }

        public void Show() => _playerUi.Show();

        public void Hide() => _playerUi.Hide();

        public void SetHealth(IHealth health) => _playerUi.SetHealth(health);
    }
}