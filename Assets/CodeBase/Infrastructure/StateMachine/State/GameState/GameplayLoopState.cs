namespace CodeBase.Infrastructure.StateMachine.State.GameState
{
  /// <summary>
  /// State for the game loop.
  /// </summary>
  /// <seealso cref="IState"/>
  public class GameplayLoopState : IState
  {
    private readonly GameStateMachine _stateMachine;

    public GameplayLoopState(GameStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }
    
    public void Enter()
    {
    }

    public void Exit()
    {
    }
  }
}