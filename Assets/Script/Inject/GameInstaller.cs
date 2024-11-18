using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using Tarahiro;
using UniRx;
using gaw241117;
using gaw241117.Model;
using gaw241117.Presenter;
using gaw241117.View;
using gaw241110.presenter;
using Tarahiro.TInput;
using VContainer.Unity;
using VContainer;

namespace gaw241117.Inject
{
    public class GameInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {

            //Title
            builder.Register<TitleModel>(Lifetime.Singleton).AsImplementedInterfaces();

            //WinCount
            builder.Register<WinCountModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<WinningStreakView>().AsImplementedInterfaces();


            //Clear
            builder.Register<ClearModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<ClearView>().AsImplementedInterfaces();

            //Coin
            builder.Register<CoinModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<CoinView>().AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<CoinRigidbody>().AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<IsHeadUiView>().AsImplementedInterfaces();

            //Touch

#if ENABLE_DEBUG
            //Debug
            builder.Register<DebugManager>(Lifetime.Singleton).AsImplementedInterfaces();
#endif

            //GamaManager
            builder.Register<ManagerToModelAdapter>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<GameManager>();
                entryPoints.Add<ClearPresenter>();
                entryPoints.Add<WinCountPresenter>();
                entryPoints.Add<CoinPresenter>();
                entryPoints.Add<TTouch>();
                entryPoints.Add<TFlick>();
            });

        }
        /*
        public override void InstallBindings()
        {

            //Title
            Container.BindInterfacesTo<TitleModel>().AsSingle();
            Container.Bind<TitlePresenter>().FromComponentInHierarchy().AsSingle();

            //WinCount
            Container.BindInterfacesTo<WinCountModel>().AsSingle();
            Container.BindInterfacesTo<WinCountPresenter>().AsSingle();
            Container.BindInterfacesTo<WinningStreakView>().FromComponentInHierarchy().AsSingle();


            //Clear
            Container.BindInterfacesTo<ClearModel>().AsSingle();
            Container.BindInterfacesTo<ClearPresenter>().AsSingle();
            Container.BindInterfacesTo<ClearView>().FromComponentInHierarchy().AsSingle();

            //Coin
            Container.BindInterfacesTo<CoinModel>().AsSingle();
            Container.BindInterfacesTo<CoinPresenter>().AsSingle();
            Container.BindInterfacesTo<CoinView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<CoinRigidbody>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<IsHeadUiView>().FromComponentInHierarchy().AsSingle();

            //Touch
            Container.BindInterfacesTo<TTouch>().AsSingle();
            Container.BindInterfacesTo<TFlick>().AsSingle();

#if ENABLE_DEBUG
            //Debug
            Container.BindInterfacesTo<DebugManager>().AsSingle();
#endif


            //GamaManager
            Container.BindInterfacesTo<ManagerToModelAdapter>().AsSingle();
            Container.BindInterfacesTo<GameManager>().AsSingle();
            Container.BindInitializableExecutionOrder<GameManager>(100);
        }
        */
    }
}