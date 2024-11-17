using Cysharp.Threading.Tasks;
using gaw241117;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;
using static gaw241117.View.TouchConst;

namespace gaw241117.View
{
    public class FlickView : MonoBehaviour, IFlickView
    {
        [Inject] ITouchView _touchView;

        FlickState _state;
        Vector2 _beginScreenPoint;
        float _beginTime;
        const float c_minFlickSpeed = 50f;

        public FlickState State => _state;
        public Vector2 BeginScreenPoint => _beginScreenPoint;



        void Update()
        {
            switch (_state)
            {
                case FlickState.None:
                    if (IsFlicking(c_minFlickSpeed))
                    {
                        ChangeState(FlickState.Begin);
                    }
                    break;

                case FlickState.Begin:

                    if (IsFlicking(c_minFlickSpeed))
                    {
                        ChangeState(FlickState.Flicking);
                    }
                    else
                    {
                        ChangeState(FlickState.Stop);
                    }
                    break;

                case FlickState.Flicking:

                    if (_touchView.State != TouchState.Touching)
                    {
                        ChangeState(FlickState.End);
                    }
                    else if (IsFlicking(c_minFlickSpeed))
                    {
                        Log.DebugLog("Flicking");
                    }
                    else
                    {
                        ChangeState(FlickState.Stop);
                    }
                    break;

                case FlickState.Stop:
                case FlickState.End:
                    ChangeState(FlickState.None);
                    break;

                default:
                    break;
            }
        }

        bool IsFlicking(float speedCriteria)
        {
            if (_touchView.State == TouchState.Touching)
            {
                if(CursorSpeed() > speedCriteria)
                {
                    return true;
                }
            }

            return false;
        }

        void ChangeState(FlickState state)
        {
            switch (state)
            {
                case FlickState.Begin:
                    _beginScreenPoint = _touchView.PrevScreenPoint(c_averagedFrameCount);
                    _beginTime = _touchView.TimeOnThisFrame;
                    Log.DebugLog("Begin") ;
                    break;
                case FlickState.Flicking:
                    Log.DebugLog("Flicking");
                    break;
                case FlickState.Stop:
                    Log.DebugLog("Stop");
                    break;
                case FlickState.End:
                    Log.DebugLog("End");
                    break;

            }
            _state = state;
        }

        const int c_averagedFrameCount = 10;

        float CursorSpeed()
        {
            return (_touchView.ScreenPointOnThisFrame - _touchView.PrevScreenPoint(c_averagedFrameCount)).magnitude / (_touchView.TimeOnThisFrame - _touchView.PrevTime(c_averagedFrameCount));
        }
        public float TimeFromBegin()
        {
            return _touchView.TimeOnThisFrame - _beginTime;
        }

        public Vector2 VectorFromBegin()
        {
            return _touchView.ScreenPointOnThisFrame - _beginScreenPoint;
        }
    }
}