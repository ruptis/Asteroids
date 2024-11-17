using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.Sound
{
    public interface ISoundPlayer
    {
        void PlaySound(SoundType soundType);
    }
}