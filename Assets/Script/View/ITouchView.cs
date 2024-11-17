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
        Vector2 PrevScreenPoint(int frameCount);
        Vector2 ScreenPointOnThisFrame { get; }
        float TimeFromBegin();
        float PrevTime(int frameCount);
        float TimeOnThisFrame { get; }
    }
}