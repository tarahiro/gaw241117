using Cysharp.Threading.Tasks;
using gaw241117;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace gaw241117.View
{
    public interface IWinningStreakView
    {

        void AddStreak(int _streakCount);
        void ResetStreak();
    }
}