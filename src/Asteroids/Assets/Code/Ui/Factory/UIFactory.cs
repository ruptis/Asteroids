using Asteroids.Code.Services.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Asteroids.Code.Ui.Factory
{
    public sealed class UIFactory : IUIFactory
    {
        private readonly IAssets _assets;
        private readonly IObjectResolver _resolver;

        public UIFactory(IAssets assets, IObjectResolver resolver)
        {
            _assets = assets;
            _resolver = resolver;
        }

        public async UniTask<PlayerUI> CreateHud()
        {
            var prefab = await _assets.Load<GameObject>("Hud");
            GameObject instance = _resolver.Instantiate(prefab);
            return instance.GetComponent<PlayerUI>();
        }
    }
}