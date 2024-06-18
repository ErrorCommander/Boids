using System.Threading.Tasks;
using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
  /// <summary>
  /// Basic factory for creating anything <see cref="GameObject"/> or <see cref="Component"/>
  /// with implemented dependency with Zenject.
  /// </summary>
  public abstract class FactoryBase
  {
    private readonly DiContainer _container;
    private readonly IAssetProvider _assetProvider;

    protected FactoryBase(DiContainer container, IAssetProvider assetProvider)
    {
      _container = container;
      _assetProvider = assetProvider;
    }

    /// <summary>
    /// Creating a GameObject from a specific component on a specific path.
    /// Position and rotation as defined in the prefab.
    /// </summary>
    /// <param name="assetPath">Path to asset.</param>
    /// <param name="parent">Optional parent <see cref="Transform"/> to which the GameObject can be attached.</param>
    /// <typeparam name="TValue"> component type, must be inherited from <see cref="Component"/>.</typeparam>
    /// <returns>Resulting component on GameObject created on scene.</returns>
    protected async Task<TValue> CreateAs<TValue>(string assetPath, Transform parent = null) where TValue : Object
    {
      TValue reference = await Load<TValue>(assetPath);
      TValue gameObject = Instantiate(reference, parent);
      return Inject(gameObject);
    }

    /// <summary>
    /// Creating a GameObject from a specific component on a specific path.
    /// </summary>
    /// <param name="assetPath">Path to asset.</param>
    /// <param name="position">Position in world of created GameObject.</param>
    /// <param name="rotation">Rotation in world of created GameObject</param>
    /// <param name="parent">Optional parent <see cref="Transform"/> to which the GameObject can be attached.</param>
    /// <typeparam name="TValue"> component type, must be inherited from <see cref="Component"/>.</typeparam>
    /// <returns>Resulting component on GameObject created on scene.</returns>
    protected async Task<TValue> CreateAs<TValue>(string assetPath, Vector3 position, Quaternion rotation, Transform parent = null)
      where TValue : Object
    {
      TValue reference = await Load<TValue>(assetPath);
      TValue gameObject = Instantiate(reference, position, rotation, parent);
      return Inject(gameObject);
    }

    /// <summary>
    /// Creating a game object from a specific path.
    /// Position and rotation as defined in the prefab.
    /// </summary>
    /// <param name="assetPath">Path to asset.</param>
    /// <param name="parent">Optional parent <see cref="Transform"/> to which the GameObject can be attached.</param>
    /// <returns>Resulting <see cref="GameObject"/> created on scene.</returns>
    protected async Task<GameObject> CreateGameObject(string assetPath, Transform parent = null) => 
      await CreateAs<GameObject>(assetPath, parent);

    /// <summary>
    /// Creating a game object from a specific path.
    /// </summary>
    /// <param name="assetPath">Path to asset.</param>
    /// <param name="position">Position in world of created GameObject.</param>
    /// <param name="rotation">Rotation in world of created GameObject.</param>
    /// <param name="parent">Optional parent <see cref="Transform"/> to which the GameObject can be attached.</param>
    /// <returns>Resulting <see cref="GameObject"/> created on scene.</returns>
    protected async Task<GameObject> CreateGameObject(string assetPath, Vector3 position, Quaternion rotation, Transform parent = null) =>
      await CreateAs<GameObject>(assetPath, position, rotation, parent);

    private TValue Instantiate<TValue>(TValue reference, Transform parent = null) where TValue : Object => 
      Object.Instantiate(reference, parent);

    private TValue Instantiate<TValue>(TValue reference, Vector3 position, Quaternion rotation, Transform parent) where TValue : Object => 
      Object.Instantiate(reference, position, rotation, parent);

    private TValue Inject<TValue>(TValue obj) where TValue : Object
    {
      _container.Inject(obj);
      return obj;
    }

    private Task<GameObject> Load(string assetPath) =>
      _assetProvider.LoadGameObjectAsync(assetPath);

    private Task<TValue> Load<TValue>(string assetPath) where TValue : Object =>
      _assetProvider.LoadAsyncAs<TValue>(assetPath);
  }
}