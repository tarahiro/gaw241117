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
        [SerializeField] Rigidbody _rigidbody;
        [Inject] IStandstillable _standstillable;
        [Inject] ITouchView _touchView;

        [SerializeField] Transform _normalObject;

        bool _isInputAcceptable = false;
        bool _isCoinTurning = false;
        bool _isCoinRigidbodyPropertySaved = false;
        const float c_fakeXzDirectionMaxForceLengh = .01f;
        const float c_fakeXyScreenPointMaxLength = 500f;
        const float c_fakeYDirectionForceLengh = .03f;


        event Action _headed;
        event Action _tailed;

        public void InitializeSettle(Action headed, Action tailed)
        {
            _headed += headed;
            _tailed += tailed;
        }

        public void SetInputAcceptable()
        {
            _isInputAcceptable = true;
        }


        void Update()
        {
            if (_isInputAcceptable)
            {
                if (!_isCoinTurning)
                {
                    if (_touchView.State == TouchConst.TouchState.Begin)
                    {
                        PrepareThrowCoin().Forget();
                    }
                }
            }
        }

        async UniTask PrepareThrowCoin()
        {
            await UniTask.WaitUntil(() => _touchView.State == TouchConst.TouchState.End);
            ThrowCoin();
        }



        void ThrowCoin()
        {
            Vector2 dir = _touchView.ScreenPoint - _touchView.BeginScreenPoint;
            float xzForceLength = c_fakeXzDirectionMaxForceLengh * Mathf.Min(dir.magnitude / c_fakeXyScreenPointMaxLength, 1f);
            float x = xzForceLength * dir.x / dir.magnitude;
            float z = xzForceLength * dir.y / dir.magnitude;
            _rigidbody.AddForce(new Vector3(x, c_fakeYDirectionForceLengh, z), ForceMode.Impulse);
            _rigidbody.AddTorque(Vector3.right * Mathf.PI / 4f, ForceMode.Impulse);

            TurningCoin().Forget();
        }

        async UniTask TurningCoin()
        {
            _isCoinTurning = true;
            await _standstillable.WaitUntilStandstill();
            OnCoinStop();
        }

        void OnCoinStop()
        {
            if (IsHead())
            {
                _headed.Invoke();
            }
            else
            {
                _tailed.Invoke();
            }
            _isCoinTurning = false;
        }

        bool IsHead()
        {
            return Normal().y > 0f;
        }

        Vector3 Normal()
        {
           return (_normalObject.position - transform.position).normalized;
        }


#if ENABLE_DEBUG

        float c_ForceDirectionHeight = .5f;
        public void ForceCoinDirection(bool isHead)
        {
            _rigidbody.position = Vector3.up * c_ForceDirectionHeight;
            _rigidbody.rotation = Quaternion.identity;

            TurningCoin().Forget();

        }
#endif
    }
}