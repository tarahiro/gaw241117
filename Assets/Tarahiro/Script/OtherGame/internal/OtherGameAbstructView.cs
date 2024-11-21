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
        [Inject] readonly Func<Sprite, IOtherGameIcon> factory;
        [Inject] IOtherGameMenuView _menuView;

        [SerializeField] Button _button;
        [SerializeField] RectTransform _iconRoot;

        Subject<Unit> _selected = new Subject<Unit>();
        List<IOtherGameIcon> _iconList = new List<IOtherGameIcon>();

        public IObservable<Unit> Selected => _selected;

        const float c_iconMergin = 15f;
        public void InitializeView(List<string> spritePathList)
        {
            int iconCount = Math.Min(spritePathList.Count, OtherGameConst.c_iconNumber);
            for (int i = 0; i < spritePathList.Count && i < OtherGameConst.c_iconNumber; i++)
            {
                var v = factory.Invoke(Resources.Load<Sprite>(spritePathList[i]));
                v.transform.parent = _iconRoot;
                UiUtil.SetUiComponentOnAlinedAnchoredPosition(_iconRoot, v.transform.GetComponent<RectTransform>(), c_iconMergin, i, iconCount);
                int count = i;
                v.Button.onClick.AddListener(() => OnClickIcon(count));
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

        void OnClickIcon(int iconIndex)
        {
            _menuView.ShowView();
            _menuView.EnterWithFocusIndex(iconIndex);

        }

    }
}