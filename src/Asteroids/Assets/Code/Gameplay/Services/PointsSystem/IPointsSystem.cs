using System;

namespace Asteroids.Code.Gameplay.Services.PointsSystem
{
    public interface IPointsSystem
    {
        void AddPointsForAsteroidDestroyed();

        void AddPoints(int points);

        void ResetPoints();

        event Action<int> PointsChanged;
    }
}