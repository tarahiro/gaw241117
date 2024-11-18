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
    public interface ITurnable
    {
        bool IsTurned { get; }

        bool IsHead();
    }
}