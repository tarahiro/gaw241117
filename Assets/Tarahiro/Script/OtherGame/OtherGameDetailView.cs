using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Tarahiro;
using Tarahiro.Ui;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using TMPro;

namespace Tarahiro.OtherGame
{
    public class OtherGameDetailView : MonoBehaviour, IOtherGameDetailView
    {
        [SerializeField] TextMeshProUGUI _title;
        [SerializeField] TextMeshProUGUI _genre;
        [SerializeField] TextMeshProUGUI _description;
        [SerializeField] Image _screenShotCenter;
        [SerializeField] Image _screenShotRightTop;
        [SerializeField] Image _screenShotRightBottom;

        List<IOtherGameDetailViewArgs> _argsList;

        public void InitializeView(List<IOtherGameDetailViewArgs> argsList)
        {
            _argsList = argsList;
        }

        public void ShowView(int index)
        {
            Sink(_argsList[index]);
        }

        public void Sink(IOtherGameDetailViewArgs args)
        {
            _title.text = args.TitleName;
            _genre.text = args.GenreName;
            _description.text = args.Description;
            _screenShotCenter.sprite = Resources.Load<Sprite>(args.ScreenShotCenterPath);
            _screenShotRightTop.sprite = Resources.Load<Sprite>(args.ScreenShotRightTopPath);
            _screenShotRightBottom.sprite = Resources.Load<Sprite>(args.ScreenShotRightBottomPath);
        }
    }
}