using System.Threading.Tasks;
using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
  /// <summary>
  /// Factory for the creation and prepare of special game objects.
  /// Used specified <see cref="IAssetProvider"/> to access prefabs.
  /// </summary>
  /// <seealso cref="FactoryBase"/>
  /// <seealso cref="IGameFactory"/>
  public class GameFactory : FactoryBase, IGameFactory
  {
    public GameFactory(DiContainer container, IAssetProvider assetProvider) : base(container, assetProvider) { }

    public Task<GameObject> CreateAgent(Vector3 position, Quaternion rotation, Transform parent = null)
    {
      return CreateGameObject(AssetsPath.Agent, position, rotation, parent);
    }
  }
}