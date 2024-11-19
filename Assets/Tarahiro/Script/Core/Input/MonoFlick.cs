using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using VContainer.Unity;
using static Tarahiro.TInput.TouchConst;

namespace Tarahiro.TInput
{

    public class MonoFlick : MonoBehaviour
    {

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

                    if (TTouch.GetInstance().State != TouchState.Touching)
                    {
                        ChangeState(FlickState.End);
                    }
                    else if (IsFlicking(c_minFlickSpeed))
                    { 
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
            if (TTouch.GetInstance().State == TouchState.Touching)
            {
                if (CursorSpeed() > speedCriteria)
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
                    _beginScreenPoint = TTouch.GetInstance().PrevScreenPoint(c_averagedFrameCount);
                    _beginTime = TTouch.GetInstance().TimeOnThisFrame;
                    break;
                case FlickState.Flicking:
                    break;
                case FlickState.Stop:
                    break;
                case FlickState.End:
                    break;

            }
            _state = state;
        }

        const int c_averagedFrameCount = 10;

        float CursorSpeed()
        {
            return (TTouch.GetInstance().ScreenPointOnThisFrame - TTouch.GetInstance().PrevScreenPoint(c_averagedFrameCount)).magnitude / (TTouch.GetInstance().TimeOnThisFrame - TTouch.GetInstance().PrevTime(c_averagedFrameCount));
        }
        public float TimeFromBegin()
        {
            return TTouch.GetInstance().TimeOnThisFrame - _beginTime;
        }

        public Vector2 VectorFromBegin()
        {
            return TTouch.GetInstance().ScreenPointOnThisFrame - _beginScreenPoint;
        }
    }
}