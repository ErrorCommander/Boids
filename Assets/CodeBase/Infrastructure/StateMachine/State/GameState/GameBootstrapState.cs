namespace CodeBase.Infrastructure.StateMachine.State.GameState
{
  /// <summary>
  /// State for initialization and prepare of the game and its services.
  /// </summary>
  /// <seealso cref="IState"/>
  public class GameBootstrapState : IState
  {
    private const string _firstSceneName = "Game";

    private readonly GameStateMachine _gameStateMachine;

    public GameBootstrapState(GameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
    }

    /// <summary>
    /// Start initialization and prepare of the game and its services.
    /// </summary>
    public void Enter()
    {
      _gameStateMachine.Enter<LoadSceneState, string>(_firstSceneName);
    }

    public void Exit()
    {
    }
  }
}