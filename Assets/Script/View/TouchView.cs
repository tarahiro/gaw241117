using Cysharp.Threading.Tasks;
using gaw241117;
using PlasticGui.WorkspaceWindow.Locks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241117.View
{
    public class TouchView : MonoBehaviour, ITouchView
    {
        float _beginTime;

        public TouchConst.TouchState State { get; private set; } = TouchConst.TouchState.None;
        public Vector2 BeginScreenPoint { get; private set; }
        public Vector2 PrevScreenPoint { get; private set; }
        public Vector2 ScreenPoint { get; private set; }

        public float TimeFromBegin()
        {
            if(State == TouchConst.TouchState.None)
            {
                Log.DebugLog("不正なタイミングで時間が要求されています");
            }

            return Time.time - _beginTime;
        }

        void Update()
        {
            PrevScreenPoint = ScreenPoint;
            ScreenPoint = (Vector2)Input.mousePosition;

            switch (State)
            {
                case TouchConst.TouchState.None:
                    if (Input.GetMouseButtonDown(0))
                    {
                        ChangeTouchState(TouchConst.TouchState.Begin);
                    }
                    else if (Input.GetMouseButton(0))
                    {
                        Log.DebugWarning("不正にタッチが継続しています");
                        ChangeTouchState(TouchConst.TouchState.Begin);
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        Log.DebugWarning("不正にタッチが終了しました");
                    }
                    break;

                case TouchConst.TouchState.Begin:
                    if (Input.GetMouseButton(0))
                    {
                        ChangeTouchState(TouchConst.TouchState.Touching);
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        ChangeTouchState(TouchConst.TouchState.End);
                    }
                    else
                    {
                        Log.DebugWarning("不正にタッチが終了しました");
                        ChangeTouchState(TouchConst.TouchState.End);
                    }
                    break;

                case TouchConst.TouchState.Touching:
                    if (Input.GetMouseButton(0))
                    {
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        ChangeTouchState(TouchConst.TouchState.End);
                    }
                    else if (Input.GetMouseButtonDown(0))
                    {
                        Log.DebugWarning("不正にタッチが開始されました");
                        ChangeTouchState(TouchConst.TouchState.Begin);
                    }
                    break;

                case TouchConst.TouchState.End:
                    if (Input.GetMouseButton(0))
                    {
                        Log.DebugWarning("不正にタッチが継続しています");
                        ChangeTouchState(TouchConst.TouchState.Begin);
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        Log.DebugWarning("不正にタッチが終了しました");
                    }
                    else if (Input.GetMouseButtonDown(0))
                    {
                        ChangeTouchState(TouchConst.TouchState.Begin);
                    }
                    else
                    {
                        BeginScreenPoint = Vector2.zero;
                        ChangeTouchState(TouchConst.TouchState.None);
                    }
                    break;

                default:
                    Log.DebugWarning("不正なステートです");
                    break;
            }
        }

        void ChangeTouchState(TouchConst.TouchState state)
        {
            switch (state)
            {


                case TouchConst.TouchState.None:
                    NoneTouch();
                    break;

                case TouchConst.TouchState.Begin:
                    BeginTouch();
                    break;

                case TouchConst.TouchState.Touching:
                    Touching();
                    break;

                case TouchConst.TouchState.End:
                    EndTouch();
                    break;

                default:
                    Log.DebugWarning("不正なステートです");
                    break;
            }
        }

        void NoneTouch()
        {
            State = TouchConst.TouchState.None;
            BeginScreenPoint = Vector2.zero;
        }

        void BeginTouch()
        {
            State = TouchConst.TouchState.Begin;
            _beginTime = Time.time;
            BeginScreenPoint = ScreenPoint;
        }

        void Touching()
        {
            State = TouchConst.TouchState.Touching;

        }

        void EndTouch()
        {
            State = TouchConst.TouchState.End;
        }

    }
}