using System.Collections;
using UnityEngine;
using Tarahiro;

namespace Tarahiro.OtherGame
{
    //---プロジェクト作成時にやること---//
    //namespaceの"FakeProject"部分を変更。（gaw[yymmdd].Modelとか）

    //---クラス作成時にやること---//
    //"Template" を置換
    //フィールドを追加
    public interface IOtherGameMaster : IIdentifiable, IIndexable
    {

        /// <summary>
        /// このデータのIDを取得します。
        /// </summary>
        string CodeName { get; }

        string TitleNameJp { get; }
        string TitleNameEn { get; }
        string GenreNameJp { get; }
        string GenreNameEn { get; }
        string DescriptionJp { get; }
        string DescriptionEn { get; }
        string IconPathJp { get; }
        string IconPathEn { get; }
        string ScreenShotCenterPathJp { get; }
        string ScreenShotCenterPathEn { get; }
        string ScreenShotRightTopPathJp { get; }
        string ScreenShotRightTopPathEn { get; }
        string ScreenShotRightBottomPathJp { get; }
        string ScreenShotRightBottomPathEn { get; }
        string StoreUrlJp { get; }
        string StoreUrlEn { get; }
    }
}