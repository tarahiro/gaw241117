using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace gaw241117
{
    public class GameManager : IPostStartable
    {
        [Inject] IManagerToModelAdapter _coin;
        public void PostStart()
        {
            SoundManager.PlayBGM("Main");
            _coin.Enter();
        }
    }
}