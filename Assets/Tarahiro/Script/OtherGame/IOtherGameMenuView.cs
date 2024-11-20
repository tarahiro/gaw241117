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
        void InitializeView(List<IOtherGameMenuItemViewArgs> argsList);
        void ShowView();
    }
}