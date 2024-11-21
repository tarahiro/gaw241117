using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using Tarahiro.Ui;
using Tarahiro.UI;
using UniRx;
using UnityEngine;
using VContainer;

namespace Tarahiro.OtherGame
{
    public interface IOtherGameMenuView: IMenuView
    {
        IObservable<int> Focused { get; }
        void InitializeView(List<IOtherGameMenuItemViewArgs> argsList, Action<string> selected, ICollection<IDisposable> disposables);
        void ShowView();
        void EnterWithFocusIndex(int index);
    }
}