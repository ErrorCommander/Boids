using CodeBase.Infrastructure.SceneLoading;
using CodeBase.Services.Curtain;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.State.GameState
{
  /// <summary>
  /// State for switching game scenes.
  /// </summary>
  /// <seealso cref="IPayloadState{TPayload}"/>
  public class LoadSceneState : IPayloadState<string>
  {
    private readonly ISceneLoader _sceneLoader;
    private readonly IProgressCurtain _curtain;
    private readonly GameStateMachine _stateMachine;

    public LoadSceneState(GameStateMachine stateMachine, ISceneLoader sceneLoader, IProgressCurtain progressCurtain)
    {
      _sceneLoader = sceneLoader;
      _curtain = progressCurtain;
      _stateMachine = stateMachine;
    }

    /// <summary>
    /// Start loading scene by name with curtain display.
    /// </summary>
    /// <param name="sceneName">Loaded scene name.</param>
    public void Enter(string sceneName)
    {
      _curtain.Show();
      _sceneLoader.Load(sceneName, OnSceneLoad, _curtain.SetProgress);

      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }

    public void Exit()
    {
      _curtain.Hide();
    }

    private void OnSceneLoad()
    {
      _stateMachine.Enter<GameplayLoopState>();
    }
  }
}