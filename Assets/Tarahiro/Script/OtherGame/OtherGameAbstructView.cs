using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using Tarahiro.Ui;
using UniRx;
using UnityEngine;
using VContainer;
using TMPro;
using UnityEngine.UI;

namespace Tarahiro.OtherGame
{
    public class OtherGameAbstructView: MonoBehaviour,IOtherGameAbstructVIew
    {
        [Inject] readonly Func<Sprite, OtherGameIcon> factory;
        [Inject] IOtherGameMenuView _menuView;

        [SerializeField] Button _button;
        List<IOtherGameIcon> _iconList = new List<IOtherGameIcon>();

        Subject<Unit> _selected = new Subject<Unit>();

        public IObservable<Unit> Selected => _selected;

        public void InitializeView(List<string> spritePathList)
        {
            for (int i = 0; i < spritePathList.Count && i < OtherGameConst.c_iconNumber; i++)
            {
                var v = factory.Invoke(Resources.Load<Sprite>(spritePathList[i]));
                v.transform.parent = transform;
                v.transform.localPosition = Vector3.right * i * 200f; // fake
                _iconList.Add(v);
            }

            _button.onClick.AddListener(OnClick);
        }

        public void ShowView()
        {
            gameObject.SetActive(true);
        }

        void OnClick()
        {
            //IOtherGameMenuViewÇ…êßå‰ÇìnÇ∑
            _menuView.ShowView();
            _menuView.Enter();

            //_selected.OnNext(Unit.Default);
        }

    }
}