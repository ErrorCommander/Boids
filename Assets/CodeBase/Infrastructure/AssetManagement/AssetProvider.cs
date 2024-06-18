using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CodeBase.Infrastructure.AssetManagement
{
  /// <summary>
  /// Resource Provider implemented through the use of the "Resources" folder.
  /// </summary>
  /// <seealso cref="IAssetProvider"/>
  public class AssetProvider : IAssetProvider, ICleanable
  {
    private readonly Dictionary<string, AsyncOperationHandle> _completedCashe = new Dictionary<string, AsyncOperationHandle>();
    private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new Dictionary<string, List<AsyncOperationHandle>>();

    public AssetProvider()
    {
      Addressables.InitializeAsync();
    }

    public GameObject LoadResources(string assetPath) => Resources.Load<GameObject>(assetPath);

    public TValue LoadResourcesAs<TValue>(string assetPath) where TValue : Object => Resources.Load<TValue>(assetPath);

    public TValue[] LoadAllFromResources<TValue>(string assetsPath) where TValue : Object =>
      Resources.LoadAll<TValue>(assetsPath);

    public async Task<T> LoadAsyncAs<T>(string assetPath) where T : Object
    {
      if (_completedCashe.TryGetValue(assetPath, out AsyncOperationHandle completedHandle))
        return completedHandle.Result as T;
      
      AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(assetPath);

      return await RunWithCacheOnComplete(handle, assetPath);
    }

    public Task<GameObject> LoadGameObjectAsync(string assetPath) => 
      LoadAsyncAs<GameObject>(assetPath);

    public void Clear()
    {
      foreach (List<AsyncOperationHandle> resourceHandles in _handles.Values)
      foreach (AsyncOperationHandle handle in resourceHandles)
        Addressables.Release(handle);
      
      _completedCashe.Clear();
      _handles.Clear();
    }
    
    private async Task<T> RunWithCacheOnComplete<T>(AsyncOperationHandle<T> handle, string cacheKey) where T : class
    {
      handle.Completed += completeHandle => _completedCashe[cacheKey] = completeHandle;

      AddHandle(cacheKey, handle);

      return await handle.Task;
    }

    private void AddHandle(string key, AsyncOperationHandle handle)
    {
      if (!_handles.TryGetValue(key, out List<AsyncOperationHandle> resourceHandles))
      {
        resourceHandles = new List<AsyncOperationHandle>();
        _handles[key] = resourceHandles;
      }

      resourceHandles.Add(handle);
    }
  }
}