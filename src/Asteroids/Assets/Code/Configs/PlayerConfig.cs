using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Asteroids.Code.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public sealed class PlayerConfig : ScriptableObject
    {
        public float MovementSpeed;
        public float RotationSpeed;
        
        public float AccelerationTime;
        public float DecelerationTime;
        
        public int MaxHealth;
        
        public GunConfig GunConfig;
        public BulletsConfig BulletsConfig;
        
        public AssetReferenceGameObject PrefabReference;
    }
}