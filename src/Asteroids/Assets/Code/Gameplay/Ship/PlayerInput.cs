using Asteroids.Code.Gameplay.Movement;
using Asteroids.Code.Services.Input;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace Asteroids.Code.Gameplay.Ship
{
    public sealed class PlayerInput : MonoBehaviour
    {
        private IInputService _inputService;
        [SerializeField] private AcceleratedMovement _movement;
        [SerializeField] private Gun _gun;

        [Inject]
        public void Construct(IInputService inputService) => _inputService = inputService;
        
        private void Update()
        {
            _movement.Move(_inputService.Movement);
            if (_inputService.Fire) _gun.Fire();
        }
    }
}