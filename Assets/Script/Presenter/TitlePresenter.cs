using Cysharp.Threading.Tasks;
using gaw241117;
using gaw241117.Model;
using gaw241117.View;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace gaw241117.Presenter
{
    public class TitlePresenter : MonoBehaviour
    {
        [Inject] ITitleModel _model;
        [SerializeField] Button _button;
        [SerializeField] GameObject _uiRoot;

        //Button��View�ɂȂ�̂ŁA�ʂ�View�͗p�ӂ��Ȃ�
        //�K�v�ɂȂ�����p�ӂ���
        private void Awake()
        {
            _model.InitializeModel(OnEnterTitle, OnExitTitle);
        }

        void OnEnterTitle()
        {
            _button.onClick.AddListener(OnClick);
        }
        void OnExitTitle()
        {
            _uiRoot.SetActive(false);
        }

        void OnClick()
        {
            _model.ExitModel();
        }

    }
}