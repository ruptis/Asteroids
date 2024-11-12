using Asteroids.Code.Gameplay.Ship;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Code.Gameplay.Services.PlayerFactory
{
    public interface IPlayerFactory
    {
        UniTask<ShipBehaviour> CreatePlayer();
    }
}