using CodeBase.Gameplay;
using CodeBase.Infrastructure.Factory;

namespace CodeBase.Infrastructure.StateMachine.State.GameState
{
  /// <summary>
  /// State for the game loop.
  /// </summary>
  /// <seealso cref="IState"/>
  public class GameplayLoopState : IState
  {
    private const int _agentCount = 10;
    private readonly GameStateMachine _stateMachine;
    private readonly IGameFactory _factory;

    public GameplayLoopState(IGameFactory factory, GameStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
      _factory = factory;
    }
    
    public void Enter()
    {
      FlockHandler flockHandler = new FlockHandler(_factory, _agentCount);
    }

    public void Exit()
    {
    }
  }
}