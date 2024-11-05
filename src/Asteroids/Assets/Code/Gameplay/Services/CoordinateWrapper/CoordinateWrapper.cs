using Asteroids.Code.Gameplay.Services.Boundaries;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.CoordinateWrapper
{
    public sealed class CoordinateWrapper : ICoordinateWrapper
    {
        private readonly IBoundaries _boundaries;

        public CoordinateWrapper(IBoundaries boundaries)
        {
            _boundaries = boundaries;
        }

        public Vector2 WrapPoint(in Vector2 point) => WrapPoint(point, Vector2.zero);

        public Vector2 WrapPoint(in Vector2 point, in Vector2 correction) => new(
            WrapCoordinate(point.x, _boundaries.Min.x - correction.x, _boundaries.Max.x + correction.x),
            WrapCoordinate(point.y, _boundaries.Min.y - correction.y, _boundaries.Max.y + correction.y));

        private static float WrapCoordinate(float value, float min, float max) =>
            Mathf.Repeat(value - min, max - min) + min;
    }
}