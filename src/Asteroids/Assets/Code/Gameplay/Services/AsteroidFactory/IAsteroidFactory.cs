using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Asteroid;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.AsteroidFactory
{
    public interface IAsteroidFactory
    {
        UniTask Initialize();
        AsteroidBehaviour CreateAsteroid(AsteroidType type, Vector2 position);
    }
}