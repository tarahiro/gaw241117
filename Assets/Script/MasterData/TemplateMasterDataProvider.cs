using System.Collections;
using UnityEngine;
using Tarahiro.MasterData;
using FakeProject;

namespace FakeProject.MasterData
{
    //---プロジェクト作成時にやること---//
    //namespaceの"project"部分を変更。（gaw[yymmdd].Modelとか）

    //---クラス作成時にやること---//
    //"Template" を置換
    public class TemplateMasterDataProvider : MasterDataProvider<TemplateMasterData.Record,IMasterDataRecord<ITemplateMaster>>, ITemplateMasterDataProvider
    {
        protected override string m_pathName => "Data/Template";
    }
}