using Asteroids.Code.Gameplay.Ship;
using Asteroids.Code.Services.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Asteroids.Code.Gameplay.Services.PlayerFactory
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly IAssets _assets;
        private readonly IObjectResolver _resolver;

        public PlayerFactory(IAssets assets, IObjectResolver resolver)
        {
            _assets = assets;
            _resolver = resolver;
        }

        public async UniTask<GameObject> CreatePlayer()
        {
            var player = await _assets.Load<GameObject>("Player");
            GameObject instance = _resolver.Instantiate(player, Vector3.zero, Quaternion.identity);

            instance.GetComponent<ShipMovement>().Configure(5, 180, 1, 1);
            instance.GetComponent<Gun>().Configure(0.5f, 8);

            return instance;
        }
    }
}