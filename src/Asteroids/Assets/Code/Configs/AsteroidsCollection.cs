using UnityEngine;

namespace Asteroids.Code.Configs
{
    [CreateAssetMenu(fileName = "AsteroidsCollection", menuName = "Configs/AsteroidsCollection")]
    public sealed class AsteroidsCollection : ScriptableObject
    {
        public AsteroidConfig[] Asteroids;
    }
}