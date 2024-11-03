using Asteroids.Code.Services.LogService;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Asteroids.Code.Services.SceneManagement
{
    public sealed class SceneLoader : ISceneLoader
    {
        private readonly ILogService _logService;

        public SceneLoader(ILogService logService) =>
            _logService = logService;

        public async UniTask Load(string sceneName)
        {
            AsyncOperationHandle<SceneInstance> handle =
                Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Single, false);

            await handle.ToUniTask();
            _logService.Log($"Scene {sceneName} loaded.");
            await handle.Result.ActivateAsync().ToUniTask();
            _logService.Log($"Scene {sceneName} activated.");
        }
    }
}