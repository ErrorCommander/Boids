namespace CodeBase.Infrastructure.StateMachine.State
{
  /// <summary>
  /// Basic interface for all States.
  /// Defines a method to <see cref="Exit()"/> from state.
  /// </summary>
  public interface IExitableState
  {
    /// <summary>
    /// Necessary instructions for correctly exiting the state.
    /// </summary>
    void Exit();
  }
}