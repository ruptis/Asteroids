using Asteroids.Code.Configs;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.AsteroidDestructor
{
    public interface IAsteroidDestructor
    {
        void DestroyAsteroid(Vector2 position, Vector2 direction, AsteroidPartConfig[] parts);
    }
}