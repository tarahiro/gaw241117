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
    public interface IOtherGameDetailViewArgs
    {
        string Id { get; }
        string TitleName { get; }
        string GenreName { get; }
        string Description { get; }
        string ScreenShotCenterPath { get; }
        string ScreenShotRightTopPath { get; }
        string ScreenShotRightBottomPath { get; }
    }
}