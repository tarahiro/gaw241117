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


        public void InitializeView(List<IOtherGameMenuItemViewArgs> argsList, Action<string> selected, ICollection<IDisposable> disposables)
        {
            for (int i = 0; i < argsList.Count && i < OtherGameConst.c_iconNumber; i++)
            {
                var v = factory.Invoke(argsList[i]);
                v.transform.parent = _iconRoot;
                v.transform.localPosition = Vector3.right * i * 200f; // fake
                v.Decided.Subscribe(selected).AddTo(disposables);

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
            Focus(_index);
        }

        public void Exit()
        {
            _isInputAcceptable = false;
            UnFocus(_index);
            _root.SetActive(false);
            _exited.OnNext(Unit.Default);
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
            UnFocus(_index);
            _index = nextIndex;
            Focus(_index);
        }

        void UnFocus(int index)
        {
            _itemList[_index].UnFocus();

        }
        void Focus(int index)
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