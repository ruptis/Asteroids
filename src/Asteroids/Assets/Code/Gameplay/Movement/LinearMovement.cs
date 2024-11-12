using UnityEngine;

namespace Asteroids.Code.Gameplay.Movement
{
    public sealed class LinearMovement : MonoBehaviour
    {
        private Vector2 _velocity;

        public void Move(Vector2 velocity) => 
            _velocity = velocity;

        private void Update() => 
            transform.position += (Vector3)(_velocity * Time.deltaTime);
    }
}