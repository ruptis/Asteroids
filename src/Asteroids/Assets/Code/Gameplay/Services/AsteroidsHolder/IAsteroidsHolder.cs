using Asteroids.Code.Gameplay.Asteroid;

namespace Asteroids.Code.Gameplay.Services.AsteroidsHolder
{
    public interface IAsteroidsHolder
    {
        bool IsFull { get; }

        int AsteroidsCount { get; }

        void AddAsteroid(AsteroidBehaviour asteroid);
        void RemoveAsteroid(AsteroidBehaviour asteroid);
        
        void DestroyAllAsteroids();
    }
}