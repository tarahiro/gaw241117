using Cysharp.Threading.Tasks;
using gaw241117;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using VContainer.Unity;
using TMPro;
using LitMotion;
using LitMotion.Extensions;

namespace gaw241117.View
{
    public class IsHeadUiView : MonoBehaviour, IIsHeadUiView
    {
        [SerializeField] TextMeshProUGUI _text;

        const float c_textDisplayTime = .7f;

        public void Start()
        {
            _text.gameObject.SetActive(false);
        }

        public async UniTask Show(bool isHead)
        {
            _text.gameObject.SetActive(true);
            _text.text = isHead ? "Ç®Ç‡ÇƒÅI" : "Ç§ÇÁÅc";
            SoundManager.PlaySE(isHead ? "Win" : "Lose");
            await UniTask.WaitForSeconds(c_textDisplayTime);
            _text.gameObject.SetActive(false);
        }
    }
}