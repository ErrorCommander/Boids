using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.State;

namespace CodeBase.Infrastructure.Factory
{
  /// <summary>
  /// Factory for infrastructure objects.
  /// </summary>
  public interface IInfrastructureFactory
  {
    /// <summary>
    /// Create state for state machine.
    /// </summary>
    /// <param name="stateMachine">State machine reference. Necessary for implemented dependency.</param>
    /// <typeparam name="TState">Type a created state. Must be implement <see cref="IExitableState"/>.</typeparam>
    /// <returns>A created state with an implemented dependency.</returns>
    /// <seealso cref="IExitableState"/>
    TState CreateState<TState>(IStateMachine stateMachine) where TState : IExitableState;
  }
}