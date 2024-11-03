using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Asteroids.Code.Services.AssetManagement
{
    public sealed class AssetsProvider : IAssets
    {
        private readonly Dictionary<string, AsyncOperationHandle> _handles = new();

        public async UniTask Initialize() => await Addressables.InitializeAsync().ToUniTask();

        public async UniTask<TAsset> Load<TAsset>(string key) where TAsset : class
        {
            if (!_handles.TryGetValue(key, out AsyncOperationHandle handle))
            {
                handle = Addressables.LoadAssetAsync<TAsset>(key);
                _handles.Add(key, handle);
            }

            await handle.ToUniTask();
            return handle.Result as TAsset;
        }

        public UniTask<TAsset> Load<TAsset>(AssetReference reference) where TAsset : class =>
            Load<TAsset>(reference.AssetGUID);
        
        public async UniTask<TAsset[]> LoadAll<TAsset>(List<string> keys) where TAsset : class => 
            await UniTask.WhenAll(keys.Select(Load<TAsset>).ToList());

        public async UniTask<List<string>> GetAssetsListByLabel<TConfig>(string label) =>
            await GetAssetsListByLabel(label, typeof(TConfig));
        
        public async UniTask<List<string>> GetAssetsListByLabel(string label, Type type)
        {
            AsyncOperationHandle<IList<IResourceLocation>> operationHandle = 
                Addressables.LoadResourceLocationsAsync(label, type);

            IList<IResourceLocation> locations = await operationHandle.ToUniTask();
            
            List<string> assetKeys = locations.Select(location => location.PrimaryKey).ToList();

            Addressables.Release(operationHandle);
            return assetKeys;
        }

        public void Cleanup()
        {
            foreach (AsyncOperationHandle handle in _handles.Values) 
                Addressables.Release(handle);
            
            _handles.Clear();
        }
    }
}