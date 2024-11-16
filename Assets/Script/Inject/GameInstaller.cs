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

namespace gaw241117.Inject
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {

            //Coin
            Container.BindInterfacesTo<CoinAdapter>().AsSingle();
            Container.BindInterfacesTo<CoinModel>().AsSingle();
            Container.BindInterfacesTo<CoinPresenter>().AsSingle();
            Container.BindInterfacesTo<CoinView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<StandstillObject>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<IsHeadUiView>().FromComponentInHierarchy().AsSingle();

            //Touch
            Container.BindInterfacesTo<TouchView>().FromComponentInHierarchy().AsSingle();

#if ENABLE_DEBUG
            //Debug
            Container.BindInterfacesTo<DebugManager>().AsSingle();
#endif


            //GamaManager
            Container.BindInterfacesTo<GameManager>().AsSingle();
            Container.BindInitializableExecutionOrder<GameManager>(100);
        }
    }
}