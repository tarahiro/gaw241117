using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarahiro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Tarahiro
{
    public static class UiUtil
    {
        //Horizontalに、左から右へUIを並べるときの、AnchoredPositionを返す
        public static void SetUiComponentOnAlinedAnchoredPosition(RectTransform parentRect, RectTransform childRect,float mergin, int thisCount, int maxCount)
        {
            var parentPivotX = parentRect.pivot.x;
            var initPosition = parentPivotX * -1f * (maxCount - 1) * (childRect.sizeDelta.x + mergin);
            var positionX = initPosition + thisCount * (childRect.sizeDelta.x + mergin);
            childRect.anchoredPosition = Vector2.right * positionX;
        }

    }
}
