using System.Collections;
using UnityEngine;
using Tarahiro.MasterData;
using Tarahiro.OtherGame;

namespace Tarahiro.OtherGame.MasterData
{
    //---プロジェクト作成時にやること---//
    //namespaceの"project"部分を変更。（gaw[yymmdd].Modelとか）

    //---クラス作成時にやること---//
    //"Template" を置換
    public class OtherGameMasterDataProvider : MasterDataProvider<OtherGameMasterData.Record,IMasterDataRecord<IOtherGameMaster>>, IOtherGameMasterDataProvider
    {
        protected override string m_pathName => "Data/OtherGame";
    }
}