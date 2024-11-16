using UnityEngine;

namespace Asteroids.Code.Configs
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        public int PointsPerAsteroid;
        
        public int AsteroidsCount;
        public int MaxAsteroidsCount;
    }
}