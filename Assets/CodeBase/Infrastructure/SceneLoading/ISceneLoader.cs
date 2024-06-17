using System;

namespace CodeBase.Infrastructure.SceneLoading
{
  /// <summary>
  /// Scene loader service.
  /// </summary>
  public interface ISceneLoader
  {
    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="sceneName">Scene name-identifier.</param>
    /// <param name="onLoad">Optional callback action when scene loading is completed.</param>
    /// <param name="setProgress">Optional callback action when the progress state changes.</param>
    /// <seealso cref="Action{T}"/>
    void Load(string sceneName, Action onLoad = null, Action<float> setProgress = null);
  }
}