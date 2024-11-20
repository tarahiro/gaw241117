using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using Tarahiro.Ui;
using UniRx;
using UnityEngine;
using VContainer;

namespace Tarahiro.OtherGame
{
    public class OtherGameMenuView : MonoBehaviour, IOtherGameMenuView
    {
        [Inject] readonly Func<IOtherGameMenuItemViewArgs,OtherGameMenuItemView> factory;

        List<OtherGameMenuItemView> _itemList = new List<OtherGameMenuItemView>();

        const int c_maxIndex = 5;

        bool _isInputAcceptable = false;
        int _index = 0;

        public void InitializeView(List<IOtherGameMenuItemViewArgs> argsList)
        {
            for (int i = 0; i < argsList.Count && i < OtherGameConst.c_iconNumber; i++)
            {
                var v = factory.Invoke(argsList[i]);
                v.transform.parent = transform;
                v.transform.localPosition = Vector3.right * i * 200f; // fake
                _itemList.Add(v);
            }
        }


        public void ShowView()
        {
            gameObject.SetActive(true);
        }

        public void Enter()
        {
            _isInputAcceptable = true;
        }

        public void Exit()
        {
            _isInputAcceptable = false;

        }

        void Update()
        {
            if (_isInputAcceptable)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow)){
                    ChangeFocus((c_maxIndex + _index - 1) % c_maxIndex);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    ChangeFocus((_index + 1) % c_maxIndex);
                }

            }
        }

        void ChangeFocus(int nextIndex)
        {
            _index = nextIndex;
            Log.DebugLog(_index);
        }
    }
}