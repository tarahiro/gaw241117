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
    public class OtherGameIcon : MonoBehaviour, IOtherGameIcon

    {
        [SerializeField] Image image;
        [SerializeField] Button _button;
        public Button Button => _button;

        public void Construct(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}