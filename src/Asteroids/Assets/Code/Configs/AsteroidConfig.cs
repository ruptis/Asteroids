using System;
using UnityEngine.AddressableAssets;

namespace Asteroids.Code.Configs
{
    [Serializable]
    public class AsteroidConfig
    {
        public AsteroidType Type;
        public float MovementSpeed;
        public float RotationSpeed;
        public bool IsClockwiseRotation;
        
        public AsteroidDestructionConfig DestructionConfig;
        
        public AssetReferenceGameObject PrefabReference;
    }
}