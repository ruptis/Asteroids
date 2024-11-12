using System;

namespace Asteroids.Code.Configs
{
    [Serializable]
    public class AsteroidPartConfig
    {
        public AsteroidType Type;
        
        public float MinExitAngle;
        public float MaxExitAngle;
        
        public float PositionOffset;
    }
}