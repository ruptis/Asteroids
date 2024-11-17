using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Services.Camera;
using Asteroids.Code.Services.ConfigService;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.Sound
{
    public sealed class SoundPlayer : ISoundPlayer
    {
        private readonly AudioSource _audioSource;
        private readonly AudioConfig _audioConfig;

        public SoundPlayer(ICameraProvider cameraProvider, IConfigs configs)
        {
            _audioConfig = configs.GetAudioConfig();
            _audioSource = cameraProvider.Camera.gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            _audioSource.loop = false;
        }

        public void PlaySound(SoundType soundType)
        {
            _audioSource.PlayOneShot(_audioConfig.GetClip(soundType));
        }
    }
}