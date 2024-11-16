using Cysharp.Threading.Tasks;
using gaw241117;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241117.View
{
    public interface ICoinView
    {
        void SetInputAcceptable();

#if ENABLE_DEBUG
        void ForceCoinDirection(bool isHead);
#endif
    }
}