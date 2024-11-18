using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Tarahiro.TInput
{
    public static class InputPlatformUtility
    {
        public static bool IsTouchDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
                return true;
            }
            else
            {
                if(Input.touchCount > 0)
                {
                    if(Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsTouch()
        {
            if (Input.GetMouseButton(0))
            {
                return true;
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool IsTouchUp()
        {
            if (Input.GetMouseButtonUp(0))
            {
                return true;
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static Vector2 TouchPosition()
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount > 0)
                {
                    return Input.GetTouch(0).position;
                }
                else
                {
                    Log.DebugLog("ƒ^ƒbƒ`‚³‚ê‚Ä‚¢‚È‚¢‚Ì‚ÉTouchPosition‚ªŽæ“¾‚³‚ê‚Ä‚¢‚Ü‚·");
                    return Vector2.zero;
                }
            }
            else
            {

                return (Vector2)Input.mousePosition;
            }
        }
    }
}