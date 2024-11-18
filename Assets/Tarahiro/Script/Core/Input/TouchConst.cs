using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using VContainer.Unity;

namespace Tarahiro.TInput
{
    public static class TouchConst
    {
        public enum TouchState
        {
            None,
            Begin,
            Touching,
            End,
        }
        public enum FlickState
        {
            None,
            Begin,
            Flicking,
            Stop, //タッチしながらフリックをやめたとき
            End, //タッチを外したとき
        }
    }
}