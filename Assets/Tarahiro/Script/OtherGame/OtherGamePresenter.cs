using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tarahiro;
using Tarahiro.Ui;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Tarahiro.OtherGame
{
    public class OtherGamePresenter : IOtherGamePresenter,IInitializable
    {
        [Inject] IOtherGameModel _model;
        [Inject] IOtherGameAbstructVIew _abstructView;
        [Inject] IOtherGameMenuView _menuView;
        [Inject] Func<string, string, IOtherGameMenuItemViewArgs> _factory;

        private readonly CompositeDisposable m_Disposables = new CompositeDisposable();

        public void Initialize()
        {
            _model.ModelInitialized.
                Subscribe(x => OnInitializeModel(x)).
                AddTo(m_Disposables);
            _model.InitializeModel();
        }

        void OnInitializeModel(IEnumerable<IOtherGameMaster> masterList)
        {
            List<string> pathList = masterList.Select(x => x.IconPathJp).ToList();
            _abstructView.Selected.
                   Subscribe(_ => Log.DebugLog("Selected")).
                   AddTo(m_Disposables);
            _abstructView.InitializeView(pathList);

            List<IOtherGameMenuItemViewArgs> argsList = 
                masterList.
                    Select(x => _factory.Invoke(x.IconPathJp,x.StoreUrlJp)).
                    ToList();
            _menuView.InitializeView(argsList);

        }
    }
}