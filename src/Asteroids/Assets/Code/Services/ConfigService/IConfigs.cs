using System.Collections.Generic;
using Asteroids.Code.Configs;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Services.ConfigService
{
    public interface IConfigs
    {
        UniTask Initialize();

        GameConfig GetGameConfig();

        PlayerConfig GetPlayerConfig();

        IReadOnlyList<AsteroidConfig> GetAsteroidsConfigs(AsteroidType type);
    }
}