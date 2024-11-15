using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241117
{
    public class GameManager : IInitializable
    {
        [Inject] ICoinAdapter _coin;
        public void Initialize()
        {
            _coin.StartCoin();
        }
    }
}