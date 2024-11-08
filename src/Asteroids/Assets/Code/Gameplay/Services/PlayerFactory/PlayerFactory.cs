using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Ship;
using Asteroids.Code.Services.AssetManagement;
using Asteroids.Code.Services.ConfigService;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Asteroids.Code.Gameplay.Services.PlayerFactory
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly IAssets _assets;
        private readonly IConfigs _configs;
        private readonly IObjectResolver _resolver;

        public PlayerFactory(IAssets assets, IConfigs configs, IObjectResolver resolver)
        {
            _assets = assets;
            _configs = configs;
            _resolver = resolver;
        }

        public async UniTask<GameObject> CreatePlayer()
        {
            PlayerConfig config = _configs.GetPlayerConfig();
            var player = await _assets.Load<GameObject>(config.PrefabReference);
            GameObject instance = _resolver.Instantiate(player, Vector3.zero, Quaternion.identity);

            instance.GetComponent<ShipMovement>().Configure(config.MovementSpeed, config.RotationSpeed,
                config.AccelerationTime, config.DecelerationTime);
            instance.GetComponent<Gun>().Configure(config.GunConfig.FireRate, config.GunConfig.BulletSpeed);

            return instance;
        }
    }
}