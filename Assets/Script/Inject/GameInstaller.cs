using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using Tarahiro;
using UniRx;
using gaw241117;
using gaw241117.Model;
using gaw241117.Presenter;
using gaw241117.View;
using gaw241110.presenter;
using Tarahiro.TInput;

namespace gaw241117.Inject
{
    public class GameInstaller : MonoInstaller
    {
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
            Container.BindInterfacesTo<TouchView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<FlickView>().FromComponentInHierarchy().AsSingle();

#if ENABLE_DEBUG
            //Debug
            Container.BindInterfacesTo<DebugManager>().AsSingle();
#endif


            //GamaManager
            Container.BindInterfacesTo<ManagerToModelAdapter>().AsSingle();
            Container.BindInterfacesTo<GameManager>().AsSingle();
            Container.BindInitializableExecutionOrder<GameManager>(100);
        }
    }
}