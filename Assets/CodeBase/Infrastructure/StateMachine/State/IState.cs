namespace CodeBase.Infrastructure.StateMachine.State
{
  /// <summary>
  /// Defines a method to <see cref="Enter()"/> from state.
  /// </summary>
  /// <seealso cref="IExitableState"/>
  public interface IState : IExitableState
  {
    /// <summary>
    /// Actions to enter the state.
    /// </summary>
    void Enter();
  }
}