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