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
    public class CoinModel : ICoinModel
    {
        event Action Entered;

        public void InitializeModel(Action entered)
        {
            Entered += entered;
        }

        public void EnterModel()
        {
            Entered.Invoke();
        }
    }
}