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
        public string Id { get; set; }

        public OtherGameMenuItemViewArgs(string id,string iconPath)
        {
            Id = id;
            IconPath = iconPath;
        }


    }
}