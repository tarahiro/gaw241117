﻿using System.Collections;
using UnityEngine;
using Tarahiro.MasterData;
using gaw241117;


namespace gaw241117.Model
{

    //---プロジェクト作成時にやること---//
    //namespaceの"FakeProject"部分を変更。（gaw[yymmdd].Modelとか）

    //---クラス作成時にやること---//
    //"Template" を置換
    public interface ITemplateMasterDataProvider : IMasterDataProvider<IMasterDataRecord<ITemplateMaster>>
    {

    }
}