using Asteroids.Code.Gameplay.Bullet;
using Asteroids.Code.Gameplay.Services.BulletFactory;
using Asteroids.Code.Gameplay.Services.Sound;
using UnityEngine;
using VContainer;

namespace Asteroids.Code.Gameplay.Ship
{
    public sealed class Gun : MonoBehaviour
    {
        public Transform FirePoint;

        private float _fireRate;
        private float _bulletSpeed;

        private IBulletFactory _bulletFactory;
        private ISoundPlayer _soundPlayer;
        private float _fireTimer;

        [Inject]
        public void Construct(IBulletFactory bulletFactory, ISoundPlayer soundPlayer)
        {
            _bulletFactory = bulletFactory;
            _soundPlayer = soundPlayer;
        }

        public void Configure(float fireRate, float bulletSpeed)
        {
            _fireRate = fireRate;
            _bulletSpeed = bulletSpeed;
        }

        public void Fire()
        {
            if (_fireTimer < _fireRate) return;

            BulletBehaviour bullet = _bulletFactory.CreateBullet(FirePoint.position);
            bullet.Launch(FirePoint.up * _bulletSpeed);
            _soundPlayer.PlaySound(SoundType.Shoot);

            _fireTimer = 0;
        }

        private void Update()
        {
            _fireTimer += Time.deltaTime;
        }
    }
}