using System.Collections;
using UnityEngine;
using Tarahiro.MasterData;


namespace Tarahiro.OtherGame
{

    //---プロジェクト作成時にやること---//
    //namespaceの"FakeProject"部分を変更。（gaw[yymmdd].Modelとか）

    //---クラス作成時にやること---//
    //"OtherGame" を置換
    public interface IOtherGameMasterDataProvider : IMasterDataProvider<IMasterDataRecord<IOtherGameMaster>>
    {

    }
}