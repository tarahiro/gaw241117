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

namespace Tarahiro.OtherGame
{
    public class OtherGameAbstructView: MonoBehaviour,IOtherGameAbstructVIew
    {
        [Inject] readonly Func<Sprite, OtherGameIcon> factory;


        [SerializeField] TextMeshProUGUI _fakeText;
        [SerializeField] Transform _objectRoot;
        List<IOtherGameIcon> _iconList = new List<IOtherGameIcon>();

        const int c_iconNumber = 5;

        public void InitializeView(List<string> spritePathList)
        {
            for (int i = 0; i < spritePathList.Count && i < c_iconNumber; i++)
            {
                var v = factory.Invoke(Resources.Load<Sprite>(spritePathList[i]));
                v.transform.parent = _objectRoot;
                v.transform.localPosition = Vector3.right * i * 200f; // fake
                _iconList.Add(v);
            }
        }

        public void ShowView()
        {
            _objectRoot.gameObject.SetActive(true);
        }
    }
}