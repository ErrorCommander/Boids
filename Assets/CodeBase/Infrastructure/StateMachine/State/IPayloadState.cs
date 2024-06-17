namespace CodeBase.Infrastructure.StateMachine.State
{
  /// <summary>
  /// Defines a method to <see cref="Enter(TPayload)"/> from state with payload.
  /// </summary>
  /// <typeparam name="TPayload">Type of payload for the state.</typeparam>
  /// <seealso cref="IExitableState"/>
  public interface IPayloadState<in TPayload> : IExitableState
  {
    /// <summary>
    /// Method with payload to enter the state.
    /// </summary>
    /// <param name="payload">Payload value.</param>
    void Enter(TPayload payload);
  }
}