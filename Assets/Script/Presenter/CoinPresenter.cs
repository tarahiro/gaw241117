using Cysharp.Threading.Tasks;
using gaw241117;
using gaw241117.Model;
using gaw241117.View;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241117.Presenter
{
    public class CoinPresenter : IInitializable
    {
        [Inject] ICoinModel _model;
        [Inject] ICoinView _view;

        public void Initialize()
        {
            _model.InitializeModel(OnEnterModel);
        }

        void OnEnterModel()
        {
            _view.SetInputAcceptable(true);
        }

    }
}