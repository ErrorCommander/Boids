using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public interface ICoroutineRunner
  {
    /// <summary>
    /// Starting the execution of the coroutine.
    /// </summary>
    /// <param name="coroutine">Coroutine method to be run.</param>
    /// <returns>Reference started coroutine.</returns>
    Coroutine StartCoroutine(IEnumerator coroutine);

    /// <summary>
    /// Stops specified coroutine.
    /// </summary>
    /// <param name="coroutine">Coroutine to be stopped.</param>
    void StopCoroutine(Coroutine coroutine);
  }
}