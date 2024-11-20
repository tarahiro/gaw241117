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
    public interface IOtherGameModel
    {
         IObservable<List<string>> ModelInitialized { get; }

        void InitializeModel();
    }
}