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
    public class WinCountModel : IWinCountModel
    {
        const int c_victoryNumber = 5;
        int _winningStreakCount = 0;

        event Action _winned;
        event Action _losed;
        event Action<int> _winningStreaked;
        event Action _streakStopped;
        event Action _victoried;

        public void InitializeModel(Action winned,Action losed, Action<int> winningStreaked, Action streakStopped,Action victoried)
        {
            _winned += winned;
            _losed += losed;
            _winningStreaked += winningStreaked;
            _streakStopped += streakStopped;
            _victoried += victoried;
        }

        public void Win()
        {
            _winningStreakCount++;
            _winned.Invoke();
            _winningStreaked.Invoke(_winningStreakCount);

            if (_winningStreakCount >= c_victoryNumber)
            {
                _victoried();
            }
        }
        public void Lose()
        {
            _losed.Invoke();
            if(_winningStreakCount > 0)
            {
                _streakStopped.Invoke();
                _winningStreakCount = 0;
            }

        }
    }
}