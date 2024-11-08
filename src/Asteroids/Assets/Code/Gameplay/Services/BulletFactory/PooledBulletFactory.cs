using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Bullet;
using Asteroids.Code.Services.AssetManagement;
using Asteroids.Code.Services.ConfigService;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;

namespace Asteroids.Code.Gameplay.Services.BulletFactory
{
    public sealed class PooledBulletFactory : IBulletFactory
    {
        private const string ParentName = "Bullets";

        private readonly IAssets _assets;
        private readonly IConfigs _configs;
        private readonly IObjectResolver _resolver;

        private ObjectPool<BulletBehaviour> _bullets;

        private BulletsConfig _config;
        private GameObject _bulletPrefab;
        private Transform _bulletsParent;

        public PooledBulletFactory(IAssets assets, IConfigs configs, IObjectResolver resolver)
        {
            _assets = assets;
            _configs = configs;
            _resolver = resolver;
        }

        public async UniTask Initialize()
        {
            _config = _configs.GetPlayerConfig().BulletsConfig;
            _bullets = new ObjectPool<BulletBehaviour>(CreateNewBullet, OnGetBullet, OnReleaseBullet,
                null, false, _config.InitialPoolSize, _config.MaxPoolSize);

            _bulletPrefab = await _assets.Load<GameObject>(_config.PrefabReference);
            _bulletsParent = new GameObject(ParentName).transform;

            for (var i = 0; i < _config.InitialPoolSize; i++) _bullets.Release(CreateNewBullet());
        }

        public BulletBehaviour CreateBullet(Vector2 position)
        {
            BulletBehaviour bullet = _bullets.Get();
            bullet.transform.position = position;
            bullet.SetLifetime(_config.BulletLifeTime);
            return bullet;
        }

        private BulletBehaviour CreateNewBullet()
        {
            var bullet = _resolver.Instantiate(_bulletPrefab, _bulletsParent).GetComponent<BulletBehaviour>();
            bullet.Destroyed += () => _bullets.Release(bullet);
            return bullet;
        }

        private static void OnGetBullet(BulletBehaviour bullet) =>
            bullet.gameObject.SetActive(true);

        private static void OnReleaseBullet(BulletBehaviour bullet) =>
            bullet.gameObject.SetActive(false);
    }
}