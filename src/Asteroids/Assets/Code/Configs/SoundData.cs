using System;
using Asteroids.Code.Gameplay.Services.Sound;
using UnityEngine;

namespace Asteroids.Code.Configs
{
    [Serializable]
    public struct SoundData
    {
        public SoundType Type;
        public AudioClip Clip;
    }
}