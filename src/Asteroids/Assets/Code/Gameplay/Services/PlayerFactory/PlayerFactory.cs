using Asteroids.Code.Gameplay.Services.Boundaries;
using Asteroids.Code.Gameplay.Ship;
using Asteroids.Code.Services.AssetManagement;
using Asteroids.Code.Services.ConfigService;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using VContainer.Unity;

namespace Asteroids.Code.Gameplay.Services.PlayerFactory
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly IAssets _assets;
        private readonly IObjectResolver _resolver;
        private readonly IBoundaries _boundaries;

        private readonly AssetReferenceGameObject _assetReference;

        public PlayerFactory(IAssets assets, IObjectResolver resolver, IBoundaries boundaries, IConfigs configs)
        {
            _assets = assets;
            _resolver = resolver;
            _boundaries = boundaries;
            _assetReference = configs.GetPlayerConfig().PrefabReference;
        }

        public async UniTask<ShipBehaviour> CreatePlayer()
        {
            var player = await _assets.Load<GameObject>(_assetReference);
            GameObject instance = _resolver.Instantiate(player, _boundaries.Center, Quaternion.identity);
            return instance.GetComponent<ShipBehaviour>();
        }
    }
}