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
        [SerializeField] Transform _normalObject;

        bool _isInputAcceptable = false;
        bool _isCoinMoving = false;
        bool _isCoinRigidbodyPropertySaved = false;
        const float c_fakeXzDirectionMaxForceLengh = .01f;
        const float c_fakeXyScreenPointMaxLength = 500f;
        const float c_fakeYDirectionForceLengh = .03f;

        Vector3 _prevPosition;
        Quaternion _prevQuaternion;
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
                        Vector2 dir = _touchView.ScreenPoint - _touchView.BeginScreenPoint;
                        float xzForceLength = c_fakeXzDirectionMaxForceLengh * Mathf.Min(dir.magnitude / c_fakeXyScreenPointMaxLength, 1f);
                        float x = xzForceLength * dir.x / dir.magnitude;
                        float z = xzForceLength * dir.y / dir.magnitude;
                        _rigidbody.AddForce(new Vector3(x, c_fakeYDirectionForceLengh, z), ForceMode.Impulse);
                        _rigidbody.AddTorque(Vector3.right * Mathf.PI / 4f, ForceMode.Impulse);

                        _isCoinMoving = true;
                        _isCoinRigidbodyPropertySaved = false;
                    }
                }
            }
        }

        void FixedUpdate()
        {
            if (_isCoinMoving)
            {
                if (!_isCoinRigidbodyPropertySaved)
                {
                    _prevPosition = _rigidbody.position;
                    _prevQuaternion = _rigidbody.rotation;
                    _isCoinRigidbodyPropertySaved = true;

                }
                else
                {
                    if (_rigidbody.position == _prevPosition && _rigidbody.rotation == _prevQuaternion)
                    {
                        _isCoinMoving = false;
                        Log.DebugLog(IsHead().ToString());
                    }
                    else
                    {
                        _prevPosition = _rigidbody.position;
                        _prevQuaternion = _rigidbody.rotation;
                    }
                }
            }
        }

        public enum CoinState
        {

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
            //�}�E�X���x�ɂ���āAxy�����̏������ω��B�x������ƁA��΂Ȃ�
            //�}�E�X�����ɂ���āAxy�����̃x�N�g�����ω�
            //z�����̏����͕ω��Ȃ�

            //Input.GetTouch(0).phase

            //�ȉ��͕K�{
            //���������ɉ�]����


           
            //�ȉ��͂�ꂽ����
            //�}�E�X����������ԂŃN���b�N����ƁA�R�C�������������������ɂȂ�
            //�}�E�X�̋O�Ղ������łȂ��ƁA������]�ɂȂ�

        }

    }
}