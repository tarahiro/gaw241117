using Cysharp.Threading.Tasks;
using gaw241117;
using gaw241117.Model;
using gaw241117.View;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using Tarahiro.OtherGame;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace gaw241117.Presenter
{
    public class TitlePresenter : MonoBehaviour
    {
        [Inject] ITitleModel _model;
        [Inject] IOtherGameAbstructVIew _otherGameAbstructVIew;

        [SerializeField] Button _button;
        [SerializeField] GameObject _uiRoot;

        //ButtonがViewになるので、個別のViewは用意しない
        //必要になったら用意する
        private void Start()
        {
            _model.InitializeModel(OnEnterTitle, OnExitTitle);
        }

        void OnEnterTitle()
        {
            _otherGameAbstructVIew.ShowView();
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