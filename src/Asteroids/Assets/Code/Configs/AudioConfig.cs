using System;
using Asteroids.Code.Gameplay.Services.Sound;
using UnityEngine;

namespace Asteroids.Code.Configs
{
    [CreateAssetMenu(fileName = "AudioConfig", menuName = "Configs/AudioConfig")]
    public sealed class AudioConfig : ScriptableObject
    {
        public SoundData[] Sounds;
        
        public AudioClip GetClip(SoundType soundType)
        {
            return Array.Find(Sounds, soundData => soundData.Type == soundType).Clip;
        }
    }
}