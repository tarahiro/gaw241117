using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241117.Model;
using gaw241117.View;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public class WinCountPresenter
    {
        [Inject] IWinCountModel _model;
        [Inject] ICoinView _coinView;

        void OnHead()
        {
            _model.Win();
        }

        void OnTail()
        {
            _model.Lose();
        }
    }
}