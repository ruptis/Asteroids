using Asteroids.Code.Gameplay.Services.Camera;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.Boundaries
{
    public sealed class ScreenBoundaries : IBoundaries
    {
        public Vector2 Min { get; }
        public Vector2 Max { get; }

        public Vector2 Center { get; }

        public ScreenBoundaries(ICameraProvider cameraProvider)
        {
            UnityEngine.Camera camera = cameraProvider.Camera;
            var halfHeight = camera.orthographicSize;
            var halfWidth = halfHeight * camera.aspect;
            Min = new Vector2(-halfWidth, -halfHeight);
            Max = new Vector2(halfWidth, halfHeight);
            Center = Vector2.zero;
        }
    }
}