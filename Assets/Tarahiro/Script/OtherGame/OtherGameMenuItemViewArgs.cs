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
    public class OtherGameMenuItemViewArgs : IOtherGameMenuItemViewArgs
    {

        public string IconPath { get; set; }
        public string Url { get; set; }

        public OtherGameMenuItemViewArgs(string iconPath, string url)
        {
            IconPath = iconPath;
            Url = url;

        }


    }
}