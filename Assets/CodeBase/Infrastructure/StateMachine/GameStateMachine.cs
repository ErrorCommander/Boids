using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.StateMachine.State;
using CodeBase.Infrastructure.StateMachine.State.GameState;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine
{
  /// <summary>
  /// Performs switching between states.
  /// </summary>
  /// <seealso cref="IStateMachine"/>
  /// <seealso cref="IStateMachinePayload"/>
  public class GameStateMachine : IStateMachine, IStateMachinePayload
  {
    private const string _enterStateMessage = "GameStateMachine: Enter to state -> <color=#00DD00>{0}</color>";
    
    /// <summary>
    /// Type current game state.
    /// </summary>
    public Type CurrentState => _currentState.GetType();
    
    private readonly Dictionary<Type, IExitableState> _states;
    private IExitableState _currentState;

    public GameStateMachine(IInfrastructureFactory factory)
    {
      _states = new Dictionary<Type, IExitableState>
      {
        { typeof(GameBootstrapState), factory.CreateState<GameBootstrapState>(this) },
        { typeof(LoadSceneState), factory.CreateState<LoadSceneState>(this) },
        { typeof(GameplayLoopState), factory.CreateState<GameplayLoopState>(this) },
      };
    }

    public void Enter<TState>() where TState : class, IState
    {
      TState state = ChangeNextState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
    {
      TState state = ChangeNextState<TState>();
      state.Enter(payload);
    }

    private TState ChangeNextState<TState>() where TState : class, IExitableState
    {
      _currentState?.Exit();
      Debug.Log(string.Format(_enterStateMessage, typeof(TState).Name));
      TState state = (TState)_states[typeof(TState)];
      _currentState = state;
      return state;
    }
  }
}