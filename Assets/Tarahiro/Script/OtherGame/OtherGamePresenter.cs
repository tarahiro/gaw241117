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

        public void Initialize()
        {
            _model.InitializeModel(OnInitializeModel);
        }

        void OnInitializeModel(List<string> spritePathList)
        {
            _abstructView.InitializeView(spritePathList);
        }
    }
}