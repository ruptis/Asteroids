namespace Asteroids.Code.Gameplay.Services.Camera
{
    public sealed class CameraProvider : ICameraProvider
    {
        public UnityEngine.Camera Camera { get; }

        public CameraProvider(UnityEngine.Camera camera) => Camera = camera;
    }
}