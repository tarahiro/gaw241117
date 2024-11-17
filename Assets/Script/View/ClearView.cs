using Cysharp.Threading.Tasks;
using gaw241117;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241117.View
{
    public class ClearView : MonoBehaviour, IClearView
    {
        [SerializeField] GameObject _uiRoot;

        event Action _toTitleSelected;

        public void InitializeView(Action toTitleSelected)
        {
            _toTitleSelected += toTitleSelected;
        }

        void Start()
        {
            _uiRoot.SetActive(false);
        }

        public void Clear()
        {
            _uiRoot.SetActive(true);
        }

        public void OnClick()
        {
            _toTitleSelected.Invoke();
        }
    }
}