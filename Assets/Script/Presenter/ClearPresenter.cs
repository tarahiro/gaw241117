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
using VContainer;
using VContainer.Unity;

namespace gaw241117.Presenter
{
    public class ClearPresenter : IInitializable
    {
        [Inject] IClearModel _model;
        [Inject] IClearView _view;

        public void Initialize()
        {
            _view.InitializeView(OnTitleSelected);
        }

        void OnTitleSelected()
        {
            _model.ToTitle();
        }

    }
}