using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.SceneLoading;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.State.GameState;
using CodeBase.Services.Curtain;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
  /// <summary>
  /// Entry point to the game. Binds dependencies in DI and starts game initialization.
  /// </summary>
  /// <seealso cref="MonoInstaller"/>
  /// <seealso cref="ICoroutineRunner"/>
  public class GameBootstrapper : MonoInstaller, ICoroutineRunner
  {
    private IAssetProvider _assetProvider;
    private GameStateMachine _gameStateMachine;

    // ReSharper disable Unity.PerformanceAnalysis
    public override void InstallBindings()
    {
      BindInfrastructureFactory();
      BindCoroutineRunner();
      BindProgressCurtain();
      BindAssetProvider();
      BindSceneLoader();
      
      BindGameStateMachine();
    }

    public override void Start()
    {
      EnterToBootstrapState();
    }

    private void EnterToBootstrapState()
    {
      _gameStateMachine = Container.Resolve<GameStateMachine>();
      _gameStateMachine.Enter<GameBootstrapState>();
    }

    private void BindInfrastructureFactory() => Container.Bind<IInfrastructureFactory>()
                                                         .To<InfrastructureFactory>()
                                                         .AsSingle()
                                                         .NonLazy();
    
    private void BindCoroutineRunner()       => Container.Bind<ICoroutineRunner>()
                                                         .FromInstance(this)
                                                         .AsSingle()
                                                         .NonLazy();

    private void BindAssetProvider()         => Container.Bind<IAssetProvider>()
                                                         .To<ResourcesAssetProvider>()
                                                         .AsSingle()
                                                         .NonLazy();

    private void BindProgressCurtain()       => Container.Bind<IProgressCurtain>()
                                                         .FromMethod(CreateLoadingCurtain)
                                                         .AsSingle()
                                                         .NonLazy();

    private void BindSceneLoader()           => Container.Bind<ISceneLoader>()
                                                         .To<SimpleSceneLoader>()
                                                         .AsSingle()
                                                         .NonLazy();
    private void BindGameStateMachine()      => Container.Bind<GameStateMachine>()
                                                         .AsSingle();
    
    private LoadingCurtain CreateLoadingCurtain(InjectContext context) => 
      Instantiate(Load<LoadingCurtain>(context, AssetsPath.LoadingCurtain));
    
    private TValue Load<TValue>(InjectContext context, string path) where TValue : Object
    {
      _assetProvider ??= context.Container.Resolve<IAssetProvider>();
      return _assetProvider.LoadAs<TValue>(path);
    }
  }
}