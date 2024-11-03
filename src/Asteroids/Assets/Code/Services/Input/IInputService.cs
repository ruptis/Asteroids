using UnityEngine;

namespace Asteroids.Code.Services.Input
{
    public interface IInputService
    {
        Vector2 Movement { get; }

        bool Fire { get; }

        void Enable();

        void Disable();
    }
}