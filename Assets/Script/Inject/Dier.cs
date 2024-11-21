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
using Tarahiro.UI;
using Tarahiro.OtherGame;
using Tarahiro.OtherGame.MasterData;
using Tarahiro.TInput;
using VContainer;

namespace gaw241117.Inject
{
    public class Dier : LifetimeScope
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


#if ENABLE_DEBUG
            //Debug
            builder.Register<DebugManager>(Lifetime.Singleton).AsImplementedInterfaces();
#endif


            //OtherGame
            builder.RegisterComponentInHierarchy<OtherGameAbstructView>().AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<OtherGameMenuView>().AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<OtherGameDetailView>().AsImplementedInterfaces();
            builder.Register<OtherGameModel>(Lifetime.Singleton).WithParameter<string>("gaw241117").AsImplementedInterfaces();
            builder.Register<OtherGameMasterDataProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterFactory<Sprite, IOtherGameIcon>(container =>
            {
                
                return sprite =>
                {
                    var prefab = Resources.Load<OtherGameIcon>("Prefab/OtherGameIcon");
                    OtherGameIcon instance = container.Instantiate(prefab);
                    instance.Construct(sprite);
                    return instance;
                };
            }, Lifetime.Scoped);

            builder.RegisterFactory<IOtherGameMenuItemViewArgs, IOtherGameMenuItemView>(container =>
            {
                return args =>
                {
                    var prefab = Resources.Load <OtherGameMenuItemView>("Prefab/OtherGameMenuItemView");
                    OtherGameMenuItemView instance = container.Instantiate(prefab);
                    instance.Construct(args);
                    return instance;
                };
            }, Lifetime.Scoped);

            builder.RegisterFactory<IOtherGameMaster, IOtherGameMenuItemViewArgs>(m=> new OtherGameMenuItemViewArgs(m.Id,m.IconPathJp));

            builder.RegisterFactory<IOtherGameMaster, IOtherGameDetailViewArgs>(x => new OtherGameDetailViewArgs(x.Id, x.TitleNameJp,x.GenreNameJp, x.DescriptionJp,x.ScreenShotCenterPathJp,x.ScreenShotRightTopPathJp,x.ScreenShotRightBottomPathJp));



            //GamaManager
            builder.Register<ManagerToModelAdapter>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            {
                entryPoints.Add<GameManager>();
                entryPoints.Add<ClearPresenter>();
                entryPoints.Add<WinCountPresenter>();
                entryPoints.Add<CoinPresenter>();

                //Touch
                entryPoints.Add<TTouch>();
                entryPoints.Add<TFlick>();
                entryPoints.Add<TCanvas>();

                //OtherGame
                entryPoints.Add<OtherGamePresenter>();
#if ENABLE_VIRTUAL_CURSOR
                entryPoints.Add<TVIrtualCursor>();
#endif
            });

        }
    }
}