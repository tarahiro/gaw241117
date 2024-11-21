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
    public class OtherGameDetailViewArgs : IOtherGameDetailViewArgs
    {

        public string Id { get; }
        public string TitleName { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }
        public string ScreenShotCenterPath { get; set; }
        public string ScreenShotRightTopPath { get; set; }
        public string ScreenShotRightBottomPath { get; set; }

        public OtherGameDetailViewArgs(string id, string titleName, string genreName, string description, string screenShotCenterPath, string screenShotRightTopPath, string screenShotRightBottomPath)
        {
            Id = id;
            TitleName = titleName;
            GenreName = genreName;
            Description = description;
            ScreenShotCenterPath = screenShotCenterPath;
            ScreenShotRightTopPath = screenShotRightTopPath;
            ScreenShotRightBottomPath = screenShotRightBottomPath;
        }
    }
}