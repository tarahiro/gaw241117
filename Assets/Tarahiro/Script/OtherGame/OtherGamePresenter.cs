using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
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

        private readonly CompositeDisposable m_Disposables = new CompositeDisposable();

        public void Initialize()
        {
            _model.ModelInitialized.
                Subscribe(x => OnInitializeModel(x)).
                AddTo(m_Disposables);
            _model.InitializeModel();
        }

        void OnInitializeModel(List<string> spritePathList)
        {
            _abstructView.Selected.
                   Subscribe(_ => Log.DebugLog("Selected")).
                   AddTo(m_Disposables);
            _abstructView.InitializeView(spritePathList);
        }
    }
}