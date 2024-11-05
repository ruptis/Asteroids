using Asteroids.Code.Gameplay.Bullet;
using Asteroids.Code.Services.AssetManagement;
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
        private readonly IObjectResolver _resolver;

        private ObjectPool<BulletBehaviour> _bullets;

        private GameObject _bulletPrefab;
        private Transform _bulletsParent;

        public PooledBulletFactory(IAssets assets, IObjectResolver resolver)
        {
            _assets = assets;
            _resolver = resolver;
        }

        public async UniTask Initialize()
        {
            const int defaultCapacity = 10;
            _bullets = new ObjectPool<BulletBehaviour>(CreateNewBullet, OnGetBullet, OnReleaseBullet,
                null, false, defaultCapacity);

            _bulletPrefab = await _assets.Load<GameObject>("Bullet");
            _bulletsParent = new GameObject(ParentName).transform;

            for (var i = 0; i < defaultCapacity; i++) _bullets.Release(CreateNewBullet());
        }

        public BulletBehaviour CreateBullet(Vector2 position)
        {
            BulletBehaviour bullet = _bullets.Get();
            bullet.transform.position = position;
            bullet.SetLifetime(2);
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