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
    public class WinningStreakView : MonoBehaviour, IWinningStreakView
    {
        [SerializeField] GameObject[] _winIconList;

        void Start()
        {
            ResetStreak();
        }

        public void AddStreak(int _streakCount)
        {
            _winIconList[_streakCount - 1].SetActive(true);
        }

        public void ResetStreak()
        {
            foreach (var winIcon in _winIconList)
            {
                winIcon.SetActive(false);
            }
        }

    }
}