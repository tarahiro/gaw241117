using Cysharp.Threading.Tasks;
using gaw241117;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace gaw241117.View
{
    public class CoinView : MonoBehaviour,ICoinView
    {
        [Inject] ITouchView _touchView;
        [SerializeField] Rigidbody _rigidbody;

        bool _isInputAcceptable = false;
        const float c_fakeXzDirectionMaxForceLengh = .01f;
        const float c_fakeXyScreenPointMaxLength = 500f;
        const float c_fakeYDirectionForceLengh = .02f;
        public void SetInputAcceptable()
        {
            _isInputAcceptable = true;
        }


        void Update()
        {
            if (_isInputAcceptable)
            {
                if (_touchView.State == TouchConst.TouchState.End)
                {
                    Vector2 dir = _touchView.ScreenPoint - _touchView.BeginScreenPoint;
                    float xzForceLength = c_fakeXzDirectionMaxForceLengh * Mathf.Min(dir.magnitude / c_fakeXyScreenPointMaxLength, 1f);
                    float x = xzForceLength * dir.x / dir.magnitude;
                    float z = xzForceLength * dir.y / dir.magnitude;
                    _rigidbody.AddForce(new Vector3(x, c_fakeYDirectionForceLengh,z), ForceMode.Impulse);
                }
            }
        }

                

        void MouseInput()
        {
            //マウス速度によって、xy方向の初速が変化。遅すぎると、飛ばない
            //マウス方向によって、xy方向のベクトルが変化
            //z方向の初速は変化なし

            //Input.GetTouch(0).phase

            //以下は必須
            //いい感じに回転する


           
            //以下はやれたらやる
            //マウスを引いた状態でクリックすると、コインも少し引いた感じになる
            //マウスの軌跡が直線でないと、汚い回転になる

        }

    }
}