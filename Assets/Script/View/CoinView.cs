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
        [Inject] IIsHeadUiView _isTailUiView;

        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] Transform _normalObject;

        bool _isInputAcceptable = false;
        bool _isCoinMoving = false;
        bool _isCoinRigidbodyPropertySaved = false;
        const float c_fakeXzDirectionMaxForceLengh = .01f;
        const float c_fakeXyScreenPointMaxLength = 500f;
        const float c_fakeYDirectionForceLengh = .03f;

        public void SetInputAcceptable()
        {
            _isInputAcceptable = true;
        }


        void Update()
        {
            if (_isInputAcceptable)
            {
                if (!_isCoinMoving)
                {
                    if (_touchView.State == TouchConst.TouchState.End)
                    {
                        ThrowCoin();
                    }
                }
            }
        }


        List<Vector3> _prevPositionList;
        List<Quaternion> _prevQuaternionList;
        const int c_saveCoordinateFrame = 3;

        void FixedUpdate()
        {
            if (_isCoinMoving)
            {
                SaveCoordinate();

                if (IsStandstill())
                {
                    _isCoinMoving = false;
                    _isTailUiView.Show(IsHead()).Forget();
                }

                /*

                if (!_isCoinRigidbodyPropertySaved)
                {
                    _isCoinRigidbodyPropertySaved = true;

                }
                else
                {
                    if (_rigidbody.position == _prevPosition && _rigidbody.rotation == _prevQuaternion)
                    {
                        _isCoinMoving = false;
                        _isTailUiView.Show(IsHead()).Forget();
                    }
                    else
                    {
                        SaveCoordinate();
                    }
                }
                */
            }
        }

        void SaveCoordinate()
        {
            _prevPositionList.Add(_rigidbody.position);
            _prevQuaternionList.Add(_rigidbody.rotation);

            if (_prevPositionList.Count > c_saveCoordinateFrame)
            {
                _prevPositionList.RemoveAt(0);
            }
            if (_prevQuaternionList.Count > c_saveCoordinateFrame)
            {
                _prevQuaternionList.RemoveAt(0);
            }
        }

        bool IsStandstill()
        {
            if (_prevPositionList.Count < c_saveCoordinateFrame)
            {
                return false;
            }
            if (_prevQuaternionList.Count < c_saveCoordinateFrame)
            {
                return false;
            }


            if (!_prevPositionList.TrueForAll(x => x == _prevPositionList[0]))
            {
                return false;
            }
            if (!_prevQuaternionList.TrueForAll(x => x == _prevQuaternionList[0]))
            {
                return false;
            }

            return true;
        }

        void ThrowCoin()
        {
            Vector2 dir = _touchView.ScreenPoint - _touchView.BeginScreenPoint;
            float xzForceLength = c_fakeXzDirectionMaxForceLengh * Mathf.Min(dir.magnitude / c_fakeXyScreenPointMaxLength, 1f);
            float x = xzForceLength * dir.x / dir.magnitude;
            float z = xzForceLength * dir.y / dir.magnitude;
            _rigidbody.AddForce(new Vector3(x, c_fakeYDirectionForceLengh, z), ForceMode.Impulse);
            _rigidbody.AddTorque(Vector3.right * Mathf.PI / 4f, ForceMode.Impulse);

            OnThrowCoin();
        }

        void OnThrowCoin()
        {
            _isCoinMoving = true;
            _isCoinRigidbodyPropertySaved = false;
            _prevPositionList = new List<Vector3>();
            _prevQuaternionList = new List<Quaternion>();
        }

        bool IsHead()
        {
            return Normal().y > 0f;
        }

        Vector3 Normal()
        {
           return (_normalObject.position - transform.position).normalized;
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

#if ENABLE_DEBUG

        float c_ForceDirectionHeight = .5f;
        public void ForceCoinDirection(bool isHead)
        {
            _rigidbody.position = Vector3.up * c_ForceDirectionHeight;
            _rigidbody.rotation = Quaternion.identity;

            OnThrowCoin();

        }
#endif
    }
}