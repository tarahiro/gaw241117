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
    public class OtherGameMenuItemView : MonoBehaviour, IMenuItemView
    {
        [Inject] readonly Func<Sprite, OtherGameIcon> factory;
        [SerializeField] GameObject _focusObject;


        string _url;

        public void Construct(IOtherGameMenuItemViewArgs args)
        {
            var v = factory.Invoke(Resources.Load<Sprite>(args.IconPath));
            v.transform.parent = transform;
            v.transform.localPosition = Vector3.zero;

            _url = args.Url;
        }

        public void Focus()
        {
            _focusObject.SetActive(true);
        }

        public void UnFocus()
        {
            _focusObject.SetActive(false);
        }

        public void Decide()
        {
            Log.DebugLog(_url);
        }

    }
}