using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;
using static Tarahiro.TInput.TouchConst;

namespace Tarahiro.TInput
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