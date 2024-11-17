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
        const int c_storedFrameCount = 100;
        List<Vector2> _prevPositionList = new List<Vector2>();
        List<float> _prevTimeList = new List<float>();

        public TouchConst.TouchState State { get; private set; } = TouchConst.TouchState.None;
        public Vector2 BeginScreenPoint { get; private set; }
        public Vector2 ScreenPointOnThisFrame => _prevPositionList[_prevPositionList.Count - 1];
        public float TimeOnThisFrame => _prevTimeList[_prevTimeList.Count - 1];

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
            _prevPositionList.Add((Vector2)Input.mousePosition);
            _prevTimeList.Add(Time.time);

            if(_prevPositionList.Count > c_storedFrameCount)
            {
                _prevPositionList.RemoveAt(0);
            }
            if (_prevTimeList.Count > c_storedFrameCount)
            {
                _prevTimeList.RemoveAt(0);
            }

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
        public Vector2 PrevScreenPoint(int frameCount)
        {
            return _prevPositionList[_prevPositionList.Count - 1 - frameCount];
        }
        public float PrevTime(int frameCount)
        {
            return _prevTimeList[_prevTimeList.Count - 1 - frameCount];
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
            BeginScreenPoint = ScreenPointOnThisFrame;
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