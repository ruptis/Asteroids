using Asteroids.Code.Gameplay.Bullet;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.BulletFactory
{
    public interface IBulletFactory
    {
        UniTask Initialize();
        BulletBehaviour CreateBullet(Vector2 position);
    }
}