using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.State;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
  /// <summary>
  /// Factory for infrastructure objects. Implemented dependency with Zenject.
  /// </summary>
  public class InfrastructureFactory : IInfrastructureFactory
  {
    private readonly DiContainer _container;

    public InfrastructureFactory(DiContainer container)
    {
      _container = container;
    }

    public T CreateState<T>(IStateMachine stateMachine) where T : IExitableState =>
      _container.Instantiate<T>(new[] { stateMachine });
  }
}