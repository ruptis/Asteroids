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

        private GameConfig _gameConfig;
        private PlayerConfig _playerConfig;
        private AudioConfig _audioConfig;
        private readonly Dictionary<AsteroidType, List<AsteroidConfig>> _asteroidsDictionary = new();

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
                LoadGameConfig(),
                LoadPlayerConfig(),
                LoadAudioConfig(),
                LoadAsteroidsCollection()
            };

            await UniTask.WhenAll(tasks);

            _logService.Log("Configs initialization finished");
        }

        public GameConfig GetGameConfig() => _gameConfig;

        public PlayerConfig GetPlayerConfig() => _playerConfig;

        public AudioConfig GetAudioConfig() => _audioConfig;

        public IReadOnlyList<AsteroidConfig> GetAsteroidsConfigs(AsteroidType type) =>
            _asteroidsDictionary[type];

        private async UniTask LoadGameConfig()
        {
            GameConfig[] configs = await GetConfigs<GameConfig>();

            if (EnsureOnlyOneConfig(configs))
                _gameConfig = configs[0];

            _logService.Log("GameConfig loaded");
        }

        private async UniTask LoadPlayerConfig()
        {
            PlayerConfig[] configs = await GetConfigs<PlayerConfig>();

            if (EnsureOnlyOneConfig(configs))
                _playerConfig = configs[0];

            _logService.Log("PlayerConfig loaded");
        }

        private async UniTask LoadAudioConfig()
        {
            AudioConfig[] configs = await GetConfigs<AudioConfig>();
            
            if (EnsureOnlyOneConfig(configs))
                _audioConfig = configs[0];
            
            _logService.Log("AudioConfig loaded");
        }

        private async UniTask LoadAsteroidsCollection()
        {
            AsteroidsCollection[] configs = await GetConfigs<AsteroidsCollection>();

            if (EnsureOnlyOneConfig(configs))
                FillAsteroidsDictionary(configs[0]);

            _logService.Log("AsteroidsCollection loaded");
        }

        private void FillAsteroidsDictionary(AsteroidsCollection asteroidsCollection)
        {
            foreach (AsteroidConfig asteroid in asteroidsCollection.Asteroids)
            {
                if (!_asteroidsDictionary.ContainsKey(asteroid.Type))
                    _asteroidsDictionary.Add(asteroid.Type, new List<AsteroidConfig>());

                _asteroidsDictionary[asteroid.Type].Add(asteroid);
            }
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