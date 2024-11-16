using Asteroids.Code.Gameplay.Ship;

namespace Asteroids.Code.Gameplay.Services.ShipDeath
{
    public interface IShipDeathObserver
    {
        void ObserveDeath(IHealth health);
    }
}