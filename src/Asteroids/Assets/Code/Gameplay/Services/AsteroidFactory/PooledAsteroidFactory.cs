using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Asteroid;
using Asteroids.Code.Services.AssetManagement;
using Asteroids.Code.Services.ConfigService;
using Asteroids.Code.Services.RandomService;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;

namespace Asteroids.Code.Gameplay.Services.AsteroidFactory
{
    public sealed class PooledAsteroidFactory : IAsteroidFactory
    {
        private const string ParentName = "Asteroids";

        private readonly IAssets _assets;
        private readonly IConfigs _configs;
        private readonly IObjectResolver _resolver;
        private readonly IRandomService _randomService;

        private readonly Dictionary<AsteroidConfig, ObjectPool<AsteroidBehaviour>> _pools = new();

        private readonly Dictionary<AsteroidConfig, GameObject> _prefabs = new();
        private Transform _asteroidsParent;

        public PooledAsteroidFactory(IAssets assets, IConfigs configs, IObjectResolver resolver,
            IRandomService randomService)
        {
            _assets = assets;
            _configs = configs;
            _resolver = resolver;
            _randomService = randomService;
        }

        public async UniTask Initialize()
        {
            foreach (AsteroidType type in Enum.GetValues(typeof(AsteroidType)).Cast<AsteroidType>())
            {
                IReadOnlyList<AsteroidConfig> asteroidsConfigs = _configs.GetAsteroidsConfigs(type);

                foreach (AsteroidConfig config in asteroidsConfigs)
                {
                    _prefabs[config] = await _assets.Load<GameObject>(config.PrefabReference);
                    _pools[config] = new ObjectPool<AsteroidBehaviour>(() => CreateNewAsteroid(config),
                        OnGetAsteroid, OnReleaseAsteroid, null, false);
                }
            }

            _asteroidsParent = new GameObject(ParentName).transform;
        }

        public AsteroidBehaviour CreateAsteroid(AsteroidType type, Vector2 position)
        {
            AsteroidConfig config = GetRandomConfigForType(type);
            AsteroidBehaviour asteroid = _pools[config].Get();
            asteroid.transform.position = position;
            return asteroid;
        }

        private AsteroidBehaviour CreateNewAsteroid(AsteroidConfig config)
        {
            var asteroid = _resolver.Instantiate(_prefabs[config], _asteroidsParent)
                .GetComponent<AsteroidBehaviour>();

            asteroid.Configure(config.MovementSpeed, config.RotationSpeed, config.IsClockwiseRotation);

            asteroid.Destroyed += () => _pools[config].Release(asteroid);

            return asteroid;
        }

        private AsteroidConfig GetRandomConfigForType(AsteroidType type)
        {
            IReadOnlyList<AsteroidConfig> asteroidsConfigs = _configs.GetAsteroidsConfigs(type);
            return asteroidsConfigs[_randomService.GetRandom(0, asteroidsConfigs.Count)];
        }

        private static void OnGetAsteroid(AsteroidBehaviour asteroid)
        {
            asteroid.gameObject.SetActive(true);
        }

        private static void OnReleaseAsteroid(AsteroidBehaviour asteroid)
        {
            asteroid.gameObject.SetActive(false);
        }
    }
}