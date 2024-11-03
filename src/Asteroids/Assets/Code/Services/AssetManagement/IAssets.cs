using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Asteroids.Code.Services.AssetManagement
{
    public interface IAssets
    {
        UniTask Initialize();

        UniTask<TAsset> Load<TAsset>(string key) where TAsset : class;
        UniTask<TAsset> Load<TAsset>(AssetReference reference) where TAsset : class;

        UniTask<TAsset[]> LoadAll<TAsset>(List<string> keys) where TAsset : class;

        UniTask<List<string>> GetAssetsListByLabel(string label, Type type);
        UniTask<List<string>> GetAssetsListByLabel<TConfig>(string label);

        void Cleanup();
    }
}