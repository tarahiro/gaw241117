using Cysharp.Threading.Tasks;
using gaw241117;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace gaw241117.View
{
    public class CoinRigidbody : MonoBehaviour, ICoinRigidbody
    {
        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] Transform _normalObject;

        const int c_saveCoordinateFrame = 3;

        bool _isCoinMoving = false;
        bool _initialHead;
        List<Vector3> _prevPositionList;
        List<Quaternion> _prevQuaternionList;

        public bool IsTurned { get; private set; }

        public async UniTask WaitUntilStandstill()
        {
            _isCoinMoving = true;
            IsTurned = false;
            _initialHead = IsHead();
            _prevPositionList = new List<Vector3>();
            _prevQuaternionList = new List<Quaternion>();
            await UniTask.WaitUntil(()=>!_isCoinMoving);

        }

        void FixedUpdate()
        {
            if (_isCoinMoving)
            {
                SaveCoordinate();

                if (!IsTurned)
                {
                    if(IsHead() != _initialHead)
                    {
                        IsTurned = true;
                    }
                }


                if (IsStandstill())
                {
                    _isCoinMoving = false;
                }
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
        public bool IsHead()
        {
            return Normal().y > 0f;
        }

        Vector3 Normal()
        {
            return (_normalObject.position - transform.position).normalized;
        }

#if ENABLE_DEBUG
        public void ForceTurn()
        {
            IsTurned = true;
        }
#endif
    }
}