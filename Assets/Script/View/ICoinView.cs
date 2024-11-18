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
    public interface ICoinView
    {
        void SetInputAcceptable(bool isAcceptable);

        void InitializeSettle(Action headed, Action tailed);

#if ENABLE_DEBUG
        void ForceCoinDirection(bool isHead);
#endif
    }
}