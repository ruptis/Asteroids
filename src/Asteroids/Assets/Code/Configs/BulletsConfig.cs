using System;
using UnityEngine.AddressableAssets;

namespace Asteroids.Code.Configs
{
    [Serializable]
    public class BulletsConfig
    {
        public float BulletLifeTime;
        
        public int InitialPoolSize;
        public int MaxPoolSize;
        
        public AssetReferenceGameObject PrefabReference;
    }
}