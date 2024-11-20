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
    public class OtherGameMenuItemView : MonoBehaviour, IOtherGameMenuItemView
    {
        [Inject] readonly Func<Sprite, IOtherGameIcon> factory;
        [SerializeField] GameObject _focusObject;

     //   Subject<Unit> _focused = new Subject<Unit>();

     //   public IObservable<Unit> Focused => _focused;

        string _id;
        Subject<string> _decided = new Subject<string>();

        public IObservable<string> Decided => _decided;
        public void Construct(IOtherGameMenuItemViewArgs args)
        {
            var v = factory.Invoke(Resources.Load<Sprite>(args.IconPath));
            v.transform.parent = transform;
            v.transform.localPosition = Vector3.zero;

            _id = args.Id;
            _focusObject.transform.SetAsLastSibling();
        }

        public void Focus()
        {
            _focusObject.SetActive(true);
    //        _focused.OnNext(Unit.Default);
        }

        public void UnFocus()
        {
            _focusObject.SetActive(false);
        }

        public void Decide()
        { 
            _decided.OnNext(_id);
        }

    }
}