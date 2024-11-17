using Cysharp.Threading.Tasks;
using gaw241110;
using gaw241117.Model;
using gaw241117.View;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241110.presenter
{
    public class WinCountPresenter : IInitializable
    {
        [Inject] IWinCountModel _model;
        [Inject] ICoinView _coinView;
        [Inject] IIsHeadUiView _isHeadUiView;
        [Inject] IWinningStreakView _winningStreakView;
        [Inject] IClearView _clearView;

        public void Initialize()
        {
            _coinView.InitializeSettle(OnHead, OnTail);
            _model.InitializeModel(OnWin, OnLose, OnWinningStreaked, OnStopStreak, OnVictoried);
        }

        void OnHead()
        {
            _model.Win();
        }

        void OnTail()
        {
            _model.Lose();
        }

        void OnWin()
        {
            _isHeadUiView.Show(true);
        }

        void OnLose()
        {
            _isHeadUiView.Show(false);
        }

        void OnWinningStreaked(int count)
        {
            _winningStreakView.AddStreak(count);
        }

        void OnStopStreak()
        {
            _winningStreakView.ResetStreak();
        }

        void OnVictoried()
        {
            _clearView.Clear();
            _coinView.SetInputAcceptable(false);
        }
    }
}