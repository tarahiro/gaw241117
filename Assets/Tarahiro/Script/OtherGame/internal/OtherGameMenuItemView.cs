using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using Tarahiro.Ui;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
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
        public Button Button { get; set; }
        public void Construct(IOtherGameMenuItemViewArgs args)
        {
            _id = args.Id;

            var v = factory.Invoke(Resources.Load<Sprite>(args.IconPath));
            v.transform.parent = transform;
            v.transform.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            Button = v.Button;

            _focusObject.transform.SetAsLastSibling();
            _focusObject.SetActive(false);
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