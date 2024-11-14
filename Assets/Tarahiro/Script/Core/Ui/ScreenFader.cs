using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarahiro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LitMotion;
using LitMotion.Extensions;
using Cysharp.Threading.Tasks;

namespace Tarahiro.Ui
{
    public class ScreenFader : MonoBehaviour, IScreenFader
    {
        [SerializeField] Image _fadeImage;

        void Start()
        {
            Color c = _fadeImage.color;
            c.a = 0f;
            _fadeImage.color = c;
        }

        public async UniTask FadeIn(float fadeInTime)
        {
            await LMotion.Create(_fadeImage.color.a, 1f, fadeInTime).
                BindToColorA(_fadeImage);
        }
        public async UniTask FadeOut(float fadeOutTime)
        {
            await LMotion.Create(_fadeImage.color.a, 0f, fadeOutTime).
                BindToColorA(_fadeImage);
        }

    }
}
