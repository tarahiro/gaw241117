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
        [SerializeField] GameObject _guideObject;
        [Inject] ICoinRigidbody _coinRigidbody;
        [Inject] ITouchView _touchView;
        [Inject] IFlickView _flickView;


        bool _isInputAcceptable = false;
        bool _isCoinTurning = false;
        bool _isCoinRigidbodyPropertySaved = false;


        event Action _headed;
        event Action _tailed;

        public void InitializeSettle(Action headed, Action tailed)
        {
            _headed += headed;
            _tailed += tailed;
        }

        public void SetInputAcceptable(bool isAcceptable)
        {
            _isInputAcceptable = isAcceptable;
            _guideObject.SetActive(isAcceptable);
        }

        void Start()
        {
            _guideObject.SetActive(false);
        }


        void Update()
        {
            if (_isInputAcceptable)
            {
                if (!_isCoinTurning)
                {
                    if (_touchView.State == TouchConst.TouchState.Begin) { 
                            PrepareThrowCoin().Forget();
                    }
                }
            }
        }

        async UniTask PrepareThrowCoin()
        {
            await UniTask.WaitUntil(() => _flickView.State == TouchConst.FlickState.End);
            ThrowCoin();
        }


        const float c_fakeXzDirectionMaxForceLengh = .01f;
        const float c_fakeXyScreenSpeedMaxLength = 10000f;
        const float c_fakeYDirectionForceLengh = .03f;

        void ThrowCoin()
        {


            Vector2 dir = _flickView.VectorFromBegin() / _flickView.TimeFromBegin();
            float forceRate = Mathf.Min(dir.magnitude / c_fakeXyScreenSpeedMaxLength, 1f);
            float xzForceLength = c_fakeXzDirectionMaxForceLengh * forceRate;
            float x = xzForceLength * dir.x / dir.magnitude;
            float z = xzForceLength * dir.y / dir.magnitude;
            _rigidbody.AddForce(new Vector3(x, c_fakeYDirectionForceLengh * forceRate, z), ForceMode.Impulse);
            _rigidbody.AddTorque(Vector3.right * Mathf.PI / 40f * forceRate , ForceMode.Impulse);
            Log.DebugLog( dir.magnitude.ToString());

            TurningCoin().Forget();
        }

        async UniTask TurningCoin()
        {
            _isCoinTurning = true;
            _guideObject.SetActive(false);
            SoundManager.PlaySE("StartCoin");

            await _coinRigidbody.WaitUntilStandstill();
            OnCoinStop();
        }

        void OnCoinStop()
        {
            _isCoinTurning = false;
            _guideObject.SetActive(true);

            if (_coinRigidbody.IsTurned)
            {
                if (_coinRigidbody.IsHead())
                {
                    _headed.Invoke();
                }
                else
                {
                    _tailed.Invoke();
                }
            }
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