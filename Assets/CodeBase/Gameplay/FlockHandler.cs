using CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace CodeBase.Gameplay
{
  public class FlockHandler
  {
    public FlockHandler(IGameFactory gameFactory, int agentCount)
    {
      for (int i = 0; i < agentCount; i++)
      {
        gameFactory.CreateAgent(Vector3.zero, Quaternion.identity);
      }
    }
  }
}