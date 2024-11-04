using Asteroids.Code.Gameplay.Ship;
using Asteroids.Code.Services.Input;
using UnityEngine;
using VContainer;

namespace Asteroids.Code.Gameplay
{
    public sealed class PlayerInput : MonoBehaviour
    {
        private IInputService _inputService;
        [SerializeField] private ShipMovement _shipMovement;

        [Inject]
        public void Construct(IInputService inputService) => _inputService = inputService;
        
        private void Update()
        {
            _shipMovement.Move(_inputService.Movement);
        }
    }
}