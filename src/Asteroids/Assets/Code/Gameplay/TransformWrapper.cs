using Asteroids.Code.Gameplay.Services.CoordinateWrapper;
using UnityEngine;
using VContainer;

namespace Asteroids.Code.Gameplay
{
    public sealed class TransformWrapper : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private ICoordinateWrapper _coordinateWrapper;

        private Vector2 _correction;

        [Inject]
        public void Construct(ICoordinateWrapper coordinateWrapper)
            => _coordinateWrapper = coordinateWrapper;

        private void Awake() => 
            _correction = _spriteRenderer ? _spriteRenderer.bounds.size / 2 : Vector2.zero;

        private void Update() =>
            transform.position = _coordinateWrapper.WrapPoint(transform.position, _correction);
    }
}