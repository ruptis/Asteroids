using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Services.Boundaries;
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
        private readonly IBoundaries _boundaries;

        public PlayerFactory(IAssets assets, IConfigs configs, IObjectResolver resolver, IBoundaries boundaries)
        {
            _assets = assets;
            _configs = configs;
            _resolver = resolver;
            _boundaries = boundaries;
        }

        public async UniTask<GameObject> CreatePlayer()
        {
            PlayerConfig config = _configs.GetPlayerConfig();
            var player = await _assets.Load<GameObject>(config.PrefabReference);
            GameObject instance = _resolver.Instantiate(player, _boundaries.Center, Quaternion.identity);

            instance.GetComponent<ShipMovement>().Configure(config.MovementSpeed, config.RotationSpeed,
                config.AccelerationTime, config.DecelerationTime);
            instance.GetComponent<Gun>().Configure(config.GunConfig.FireRate, config.GunConfig.BulletSpeed);

            return instance;
        }
    }
}