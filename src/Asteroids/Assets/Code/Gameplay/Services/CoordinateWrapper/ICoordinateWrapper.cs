using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.CoordinateWrapper
{
    public interface ICoordinateWrapper
    {
        Vector2 WrapPoint(in Vector2 point);
        Vector2 WrapPoint(in Vector2 point, in Vector2 correction);
    }
}