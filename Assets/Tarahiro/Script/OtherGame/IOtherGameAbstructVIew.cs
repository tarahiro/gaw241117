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
    public interface IOtherGameAbstructVIew
    {
        void InitializeView(List<string> spritePathList);
        public IObservable<Unit> Selected { get; }
        void ShowView();
    }
}