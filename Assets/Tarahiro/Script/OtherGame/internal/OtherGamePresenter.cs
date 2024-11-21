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
        [Inject] IOtherGameDetailView _detailView;
        [Inject] Func<IOtherGameMaster, IOtherGameMenuItemViewArgs> _menuItemViewArgsFactory;
        [Inject] Func<IOtherGameMaster, IOtherGameDetailViewArgs> _detailViewArgsFactory;

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

            List<IOtherGameMenuItemViewArgs> menuItemArgsList = 
                masterList.
                    Select(x => _menuItemViewArgsFactory.Invoke(x)).
                    ToList();

            _menuView.InitializeView(menuItemArgsList, _model.SelectOtherGame,m_Disposables);
            _menuView.Focused.Subscribe(_detailView.ShowView).AddTo(m_Disposables);

            List<IOtherGameDetailViewArgs> detailArgsList =
                masterList.
                    Select(x => _detailViewArgsFactory.Invoke(x)).
                    ToList();
            _detailView.InitializeView(detailArgsList);
            _detailView.Clicked.Subscribe(_model.SelectOtherGame).AddTo(m_Disposables);


        }
    }
}