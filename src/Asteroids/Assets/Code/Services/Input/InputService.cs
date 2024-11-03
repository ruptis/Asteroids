using UnityEngine;

namespace Asteroids.Code.Services.Input
{
    public class InputService : IInputService
    {
        public Vector2 Movement { get; }

        public bool Fire { get; }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}