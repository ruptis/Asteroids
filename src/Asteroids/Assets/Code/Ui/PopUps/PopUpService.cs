using System;
using System.Threading;
using Asteroids.Code.Ui.Factory;
using Cysharp.Threading.Tasks;
using Object = UnityEngine.Object;

namespace Asteroids.Code.Ui.PopUps
{
    public sealed class PopUpService : IPopUpService, IDisposable
    {
        private readonly IUIFactory _uiFactory;
        
        private GameOverPopup _gameOverPopup;
        private CancellationTokenSource _gameOverPopupCts;

        public PopUpService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public async UniTask<GameOverPopup.Result> ShowGameOverPopup()
        {
            _gameOverPopup = await _uiFactory.CreateGameOverPopup();
            _gameOverPopupCts = new CancellationTokenSource();
            return await _gameOverPopup.Show().AttachExternalCancellation(_gameOverPopupCts.Token);
        }

        public void HideGameOverPopup()
        {
            if (_gameOverPopup == null)
                return;
            
            _gameOverPopupCts.Cancel();
            _gameOverPopupCts.Dispose();
            Object.Destroy(_gameOverPopup.gameObject);
            
            _gameOverPopup = null;
        }

        public void Dispose()
        {
            HideGameOverPopup();
        }
    }
}