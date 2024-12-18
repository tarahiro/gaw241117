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
    public interface ICoinRigidbody : ITurnable, IStandstillable
    {
#if ENABLE_DEBUG
        void ForceTurn();
#endif
    }
}