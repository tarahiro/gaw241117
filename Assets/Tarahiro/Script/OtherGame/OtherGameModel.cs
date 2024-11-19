using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using Tarahiro.Ui;
using UniRx;
using UnityEngine;
using VContainer;

namespace Tarahiro.OtherGame
{
    public class OtherGameModel : IOtherGameModel
    {
        [Inject]
        string _gameCode;

        /*
        public OtherGameModel(string gameCode)
        {

        }
        */

        public void InitializeModel(Action<string> _fakeInitializedModel)
        {
            _fakeInitializedModel.Invoke(_gameCode);
        }
    }
}