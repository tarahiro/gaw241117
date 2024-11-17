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
    public interface ITouchView
    {
        TouchConst.TouchState State { get; }

        Vector2 BeginScreenPoint { get; }
        Vector2 PrevScreenPoint { get; }
        Vector2 ScreenPoint { get; }
        float TimeFromBegin();
    }
}