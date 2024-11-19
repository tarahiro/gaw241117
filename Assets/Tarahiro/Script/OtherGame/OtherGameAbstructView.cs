using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using Tarahiro.Ui;
using UniRx;
using UnityEngine;
using VContainer;
using TMPro;

namespace Tarahiro.OtherGame
{
    public class OtherGameAbstructView: MonoBehaviour,IOtherGameAbstructVIew
    {
        [SerializeField] TextMeshProUGUI _fakeText;
        string _gameCode;

        public void InitializeView(string gameCode)
        {
            _gameCode = gameCode;
        }

        public void ShowView()
        {
            _fakeText.text = _gameCode;
        }
    }
}