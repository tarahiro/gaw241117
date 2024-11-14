using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarahiro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Tarahiro.Ui
{
    public interface IScreenFader
    {
        UniTask FadeIn(float time);

        UniTask FadeOut(float time);
    }
}
