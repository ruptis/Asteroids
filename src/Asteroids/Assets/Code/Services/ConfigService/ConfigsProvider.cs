using System.Collections.Generic;
using Asteroids.Code.Configs;
using Asteroids.Code.Services.AssetManagement;
using Asteroids.Code.Services.LogService;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Services.ConfigService
{
    public sealed class ConfigsProvider : IConfigs
    {
        private const string Configs = "Configs";
        private readonly ILogService _logService;
        private readonly IAssets _assets;

        private PlayerConfig _playerConfig;

        public ConfigsProvider(ILogService logService, IAssets assets)
        {
            _logService = logService;
            _assets = assets;
        }

        public async UniTask Initialize()
        {
            _logService.Log("Configs initialization started");

            var tasks = new List<UniTask>
            {
                LoadPlayerConfig(),
            };

            await UniTask.WhenAll(tasks);

            _logService.Log("Configs initialization finished");
        }


        public PlayerConfig GetPlayerConfig() => _playerConfig;

        private async UniTask LoadPlayerConfig()
        {
            PlayerConfig[] configs = await GetConfigs<PlayerConfig>();

            if (EnsureOnlyOneConfig(configs))
                _playerConfig = configs[0];

            _logService.Log("PlayerConfig loaded");
        }

        private bool EnsureOnlyOneConfig<TConfig>(TConfig[] configs)
        {
            switch (configs.Length)
            {
                case 0:
                    _logService.LogError($"{typeof(TConfig).Name} not found");
                    return false;
                case > 1:
                    _logService.LogError($"Multiple {typeof(TConfig).Name} found");
                    return false;
                default:
                    return true;
            }
        }

        private async UniTask<List<string>> GetConfigKeys<TConfig>() =>
            await _assets.GetAssetsListByLabel<TConfig>(Configs);

        private async UniTask<TConfig[]> GetConfigs<TConfig>() where TConfig : class
        {
            List<string> keys = await GetConfigKeys<TConfig>();
            return await _assets.LoadAll<TConfig>(keys);
        }
    }
}