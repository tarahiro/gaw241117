using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using Tarahiro;
using UniRx;
using gaw241117;
using gaw241117.Model;
using gaw241117.Presenter;
using gaw241117.View;

namespace gaw241117.Inject
{
#if ENABLE_DEBUG
    public class DebugManager: ITickable
    {
        [Inject] ICoinView _coinView;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                _coinView.ForceCoinDirection(true);
            }
        }
    }
#endif
}