using UnityEngine;

namespace Asteroids.Code.Gameplay
{
    public sealed class Rotation : MonoBehaviour
    {
        private float _rotationSpeed;
        private bool _isClockwise;

        public void Rotate(float rotationSpeed, bool isClockwise)
        {
            _rotationSpeed = rotationSpeed;
            _isClockwise = isClockwise;
        }

        private void Update()
        {
            var rotation = _rotationSpeed * Time.deltaTime;
            rotation = _isClockwise ? rotation : -rotation;
            transform.Rotate(0, 0, rotation);
        }
    }
}