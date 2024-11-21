using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
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
        [Inject] readonly Func<IOtherGameMenuItemViewArgs,IOtherGameMenuItemView> factory;

        [SerializeField] GameObject _root;
        [SerializeField] Transform _iconRoot;

        Subject<int> _focused = new Subject<int>();
        Subject<Unit> _exited = new Subject<Unit>();
        List<IOtherGameMenuItemView> _itemList = new List<IOtherGameMenuItemView>();
        bool _isInputAcceptable = false;
        int _index = 0;

        public IObservable<Unit> Exited => _exited;
        public IObservable<int> Focused => _focused;

        void Awake()
        {
            _root.SetActive(false);
        }

        const float c_iconMergin = 15f;

        public void InitializeView(List<IOtherGameMenuItemViewArgs> argsList, Action<string> selected, ICollection<IDisposable> disposables)
        {
            int iconCount = Math.Min(argsList.Count, OtherGameConst.c_iconNumber);
            for (int i = 0; i < iconCount; i++)
            {
                var v = factory.Invoke(argsList[i]);
                v.transform.parent = _iconRoot;
                UiUtil.SetUiComponentOnAlinedAnchoredPosition(_iconRoot.GetComponent<RectTransform>(), v.transform.GetComponent<RectTransform>(),c_iconMergin,i,iconCount);
              //  v.transform.GetComponent<RectTransform>().anchoredPosition = Vector3.right * (i - (iconCount - 1)) * (v.transform.GetComponent<RectTransform>().sizeDelta.x + c_iconMergin);
                v.Decided.Subscribe(selected).AddTo(disposables);
                var count = i;
                v.Button.onClick.AddListener(delegate { ChangeFocus(count); });

                _itemList.Add(v);
            }
        }


        public void ShowView()
        {
            _root.SetActive(true);
        }

        public void Enter()
        {
            _isInputAcceptable = true;
            Focus();
        }

        public void EnterWithFocusIndex(int index)
        {
            _isInputAcceptable = true;
            _index = index;
            Focus();
        }

        public void Exit()
        {
            _isInputAcceptable = false;
            UnFocus();
            _root.SetActive(false);
            _exited.OnNext(Unit.Default);
        }

        public void OnClickedExitButton()
        {
            Exit();
        }

        void Update()
        {
            if (_isInputAcceptable)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow)){
                    ChangeFocus((OtherGameConst.c_iconNumber + _index - 1) % OtherGameConst.c_iconNumber);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    ChangeFocus((_index + 1) % OtherGameConst.c_iconNumber);
                }

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Decide();
                }

                if (Input.GetKeyDown(KeyCode.X))
                {
                    Exit();
                }

            }
        }

        void ChangeFocus(int nextIndex)
        {
            Log.DebugLog(nextIndex);
            UnFocus();
            _index = nextIndex;
            Focus();
        }

        void UnFocus()
        {
            _itemList[_index].UnFocus();

        }
        void Focus()
        {
            _itemList[_index].Focus();
            _focused.OnNext(_index);
        }

        void Decide()
        {
            _itemList[_index].Decide();
        }
    }
}