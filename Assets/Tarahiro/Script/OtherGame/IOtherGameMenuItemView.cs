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
    public interface IOtherGameMenuItemView : IMenuItemView
    {
     //   IObservable<Unit> Focused { get; }

        IObservable<string> Decided { get; }
    }
}