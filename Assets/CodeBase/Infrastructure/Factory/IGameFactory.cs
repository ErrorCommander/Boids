using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  /// <summary>
  /// Factory for the creation and prepare of special game objects.
  /// </summary>
  public interface IGameFactory
  {
    /// <summary>
    /// Create and prepare to use a Agent.
    /// </summary>
    /// <param name="position">Position in word.</param>
    /// <param name="rotation">Rotation in word.</param>
    /// <param name="parent">Optional parent <see cref="Transform"/> to which the GameObject can be attached.</param>
    /// <returns>Resulting created Furniture on stage ready for use.</returns>
    Task<GameObject> CreateAgent(Vector3 position, Quaternion rotation, Transform parent = null);
  }
}