using System;
using Asteroids.Code.Gameplay.Movement;
using Asteroids.Code.Gameplay.Services.EnginePowerService;
using UnityEngine;
using VContainer;

namespace Asteroids.Code.Gameplay.Ship
{
    [Serializable]
    public sealed class EffectSpriteConfig
    {
        public Sprite Sprite;

        [Range(0, 1)] public float Power;
    }

    public sealed class ShipEngineEffect : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _mainEngine;
        [SerializeField] private SpriteRenderer _leftEngine;
        [SerializeField] private SpriteRenderer _rightEngine;

        [SerializeField] private AcceleratedMovement _movement;

        [SerializeField] private EffectSpriteConfig[] _mainEngineSprites;
        [SerializeField] private EffectSpriteConfig[] _leftEngineSprites;
        [SerializeField] private EffectSpriteConfig[] _rightEngineSprites;
        
        private IEnginePowerService _enginePowerService;
        
        [Inject]
        public void Construct(IEnginePowerService enginePowerService)
        {
            _enginePowerService = enginePowerService;
        }

        private void Update()
        {
            if (_movement.IsAccelerating)
            {
                var powers = _enginePowerService.CalculateEnginePowers(_movement.Velocity, _movement.AngularVelocity);
                SetEnginePower(_mainEngine, _mainEngineSprites, powers.MainEnginePower);
                SetEnginePower(_leftEngine, _leftEngineSprites, powers.LeftEnginePower);
                SetEnginePower(_rightEngine, _rightEngineSprites, powers.RightEnginePower);
            }
            else
            {
                _mainEngine.sprite = null;
                _leftEngine.sprite = null;
                _rightEngine.sprite = null;
            }
        }
        
        private void SetEnginePower(SpriteRenderer engine, EffectSpriteConfig[] sprites, float power)
        {
            if (sprites.Length == 0)
            {
                engine.sprite = null;
                return;
            }

            foreach (EffectSpriteConfig config in sprites)
                if (power >= config.Power)
                {
                    engine.sprite = config.Sprite;
                    return;
                }
            
            engine.sprite = null;
        }
    }
}