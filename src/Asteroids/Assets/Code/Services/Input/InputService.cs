using Asteroids.Code.Tools;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Code.Services.Input
{
    public sealed class InputService : IInputService
    {
        private readonly Controls _controls = new();

        public Vector2 Movement { get; private set; }

        public bool Fire { get; private set; }

        public void Enable()
        {
            _controls.Player.Move.performed += OnMovement;
            _controls.Player.Move.canceled += OnMovement;

            _controls.Player.Fire.performed += OnFire;
            _controls.Player.Fire.canceled += OnFire;

            _controls.Enable();
        }

        public void Disable()
        {
            _controls.Player.Move.performed -= OnMovement;
            _controls.Player.Move.canceled -= OnMovement;

            _controls.Player.Fire.performed -= OnFire;
            _controls.Player.Fire.canceled -= OnFire;

            _controls.Disable();
            
            Movement = Vector2.zero;
            Fire = false;
        }

        private void OnMovement(InputAction.CallbackContext obj) =>
            Movement = obj.ReadValue<Vector2>();

        private void OnFire(InputAction.CallbackContext obj) =>
            Fire = obj.ReadValueAsButton();
    }
}