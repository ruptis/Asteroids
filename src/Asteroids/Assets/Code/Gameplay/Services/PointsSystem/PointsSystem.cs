using System;
using Asteroids.Code.Configs;
using Asteroids.Code.Services.ConfigService;

namespace Asteroids.Code.Gameplay.Services.PointsSystem
{
    public class PointsSystem : IPointsSystem
    {
        private readonly GameConfig _gameConfig;
        
        public PointsSystem(IConfigs configs)
        {
            _gameConfig = configs.GetGameConfig();
        }
        
        private int _points;

        public void AddPointsForAsteroidDestroyed()
        {
            AddPoints(_gameConfig.PointsPerAsteroid);
        }

        public void AddPoints(int points)
        {
            _points += points;
            PointsChanged?.Invoke(_points);
        }

        public void ResetPoints()
        {
            _points = 0;
            PointsChanged?.Invoke(_points);
        }

        public event Action<int> PointsChanged;
    }
}