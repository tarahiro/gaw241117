using System.Collections;
using UnityEngine;
using Tarahiro;

namespace FakeProject
{
    //---プロジェクト作成時にやること---//
    //namespaceの"FakeProject"部分を変更。（gaw[yymmdd].Modelとか）

    //---クラス作成時にやること---//
    //"Template" を置換
    //フィールドを追加
    public interface ITemplateMaster : IIdentifiable, IIndexable
    {

        /// <summary>
        /// このデータのIDを取得します。
        /// </summary>

        string FakeDescription{ get; }
    }
}