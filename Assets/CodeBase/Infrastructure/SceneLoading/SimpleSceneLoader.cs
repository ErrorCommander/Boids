using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.SceneLoading
{
  /// <summary>
  /// Simple scene loader based on Unity scene manager.
  /// Can only load scenes that are on the list for a build.
  /// </summary>
  /// <seealso cref="ISceneLoader"/>
  public class SimpleSceneLoader : ISceneLoader
  {
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly Stack<Action> _onSceneChange = new();
    private readonly WaitForSecondsRealtime _wait = new(0.2f);

    public SimpleSceneLoader(ICoroutineRunner coroutineRunner) =>
      _coroutineRunner = coroutineRunner;

    public void Load(string sceneName, Action onLoad = null, Action<float> setProgress = null)
    {
      OnChangeScene();
      _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoad, setProgress));
    }

    private IEnumerator LoadScene(string sceneName, Action onLoad, Action<float> setProgress)
    {
      var loading = SceneManager.LoadSceneAsync(sceneName);
      yield return _wait;
      while (!loading.isDone)
      {
        setProgress?.Invoke(loading.progress);
        yield return null;
      }

      setProgress?.Invoke(1f);
      yield return _wait;
      onLoad?.Invoke();
    }

    private void OnChangeScene()
    {
      while (_onSceneChange.Count > 0)
        _onSceneChange.Pop()?.Invoke();
    }
  }
}