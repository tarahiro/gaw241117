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