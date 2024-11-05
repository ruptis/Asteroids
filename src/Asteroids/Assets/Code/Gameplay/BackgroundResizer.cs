using Asteroids.Code.Gameplay.Services.Boundaries;
using UnityEngine;
using VContainer;

namespace Asteroids.Code.Gameplay
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class BackgroundResizer : MonoBehaviour
    {
        private IBoundaries _boundaries;
        private SpriteRenderer _background;

        [Inject]
        public void Construct(IBoundaries boundaries) => 
            _boundaries = boundaries;
        
        private void Awake() => 
            _background = GetComponent<SpriteRenderer>();
        
        private void Start() =>
            ResizeBackground();

        private void ResizeBackground()
        {
            var worldWidth = _boundaries.Max.x - _boundaries.Min.x;
            var worldHeight = _boundaries.Max.y - _boundaries.Min.y;
            var backgroundWidth = _background.size.x;
            var backgroundHeight = _background.size.y;
            var scaleX = worldWidth / backgroundWidth;
            var scaleY = worldHeight / backgroundHeight;
            transform.localScale = new Vector3(scaleX, scaleY, 1);
        }
    }
}