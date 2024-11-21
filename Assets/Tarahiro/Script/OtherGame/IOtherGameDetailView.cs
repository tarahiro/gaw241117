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
    public interface IOtherGameDetailView
    {
        void ShowView(int index);

        void InitializeView(List<IOtherGameDetailViewArgs> argsList);

        IObservable<string> Clicked { get; }
    }
}