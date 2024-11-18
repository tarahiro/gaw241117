using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using Zenject;
using static Tarahiro.TInput.TouchConst;

namespace Tarahiro.TInput
{
    public interface IFlickView
    {
        TouchConst.FlickState State { get; }

        Vector2 VectorFromBegin();
        float TimeFromBegin();
    }
}