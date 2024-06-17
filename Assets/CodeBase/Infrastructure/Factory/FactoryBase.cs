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
    protected TValue CreateAs<TValue>(string assetPath, Transform parent = null) where TValue : Component
    {
      TValue obj = _container.InstantiatePrefabForComponent<TValue>(Load<TValue>(assetPath), parent);
      return obj;
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
    protected TValue CreateAs<TValue>(string assetPath, Vector3 position, Quaternion rotation, Transform parent = null)
      where TValue : Component
    {
      TValue obj = _container.InstantiatePrefabForComponent<TValue>(Load<TValue>(assetPath), position, rotation, parent);
      return obj;
    }

    /// <summary>
    /// Creating a game object from a specific path.
    /// Position and rotation as defined in the prefab.
    /// </summary>
    /// <param name="assetPath">Path to asset.</param>
    /// <param name="parent">Optional parent <see cref="Transform"/> to which the GameObject can be attached.</param>
    /// <returns>Resulting <see cref="GameObject"/> created on scene.</returns>
    protected GameObject CreateGameObject(string assetPath, Transform parent = null)
    {
      GameObject obj = _container.InstantiatePrefab(Load(assetPath), parent);
      return obj;
    }

    /// <summary>
    /// Creating a game object from a specific path.
    /// </summary>
    /// <param name="assetPath">Path to asset.</param>
    /// <param name="position">Position in world of created GameObject.</param>
    /// <param name="rotation">Rotation in world of created GameObject.</param>
    /// <param name="parent">Optional parent <see cref="Transform"/> to which the GameObject can be attached.</param>
    /// <returns>Resulting <see cref="GameObject"/> created on scene.</returns>
    protected GameObject CreateGameObject(string assetPath, Vector3 position, Quaternion rotation, Transform parent = null)
    {
      GameObject obj = _container.InstantiatePrefab(Load(assetPath), position, rotation, parent);
      return obj;
    }

    private GameObject Load(string assetPath) =>
      _assetProvider.Load(assetPath);

    private TValue Load<TValue>(string assetPath) where TValue : Component =>
      _assetProvider.LoadAs<TValue>(assetPath);
  }
}