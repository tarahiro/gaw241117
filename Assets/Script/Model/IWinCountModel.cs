using Cysharp.Threading.Tasks;
using gaw241117;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace gaw241117.Model
{
    public interface IWinCountModel
    {
        void Win();
        void Lose();
        void InitializeModel(Action winned, Action losed, Action<int> winningStreaked, Action streakStopped, Action victoried);
    }
}