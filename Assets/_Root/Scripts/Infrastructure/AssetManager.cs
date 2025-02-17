using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure
{
    public static class AssetManager
    {
        public static async UniTask<T> LoadAssetAsync<T>(string assetName)
        {
            if (typeof(T).IsSubclassOf(typeof(Component)))
            {
                GameObject go = await Addressables.LoadAssetAsync<GameObject>(assetName);
                return go.GetComponent<T>();
            }
            return await Addressables.LoadAssetAsync<T>(assetName);
        }
        
        public static void ReleaseAsset<T>(T asset)
        {
            if (asset is GameObject go)
            {
                Addressables.ReleaseInstance(go);
            }
            else
            {
                Addressables.Release(asset);
            }
        }
    }
}