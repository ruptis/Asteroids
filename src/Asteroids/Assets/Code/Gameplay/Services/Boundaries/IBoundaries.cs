using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.Boundaries
{
    public interface IBoundaries
    {
        Vector2 Min { get; }
        Vector2 Max { get; }
        
        Vector2 Center { get; }
    }
}