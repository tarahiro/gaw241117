using Tarahiro;
using Tarahiro.MasterData;
using System;
using System.Collections;
using UnityEngine;
using FakeProject;

namespace FakeProject.MasterData
{
    //---プロジェクト作成時にやること---//
    //namespaceの"project"部分を変更。（gaw[yymmdd].Modelとか）

    //---クラス作成時にやること---//
    //"Template" を置換
    //ITemplateMasterに合わせてフィールドを追加
    public class TemplateMasterData : MasterDataOrderedDictionary<TemplateMasterData.Record, IMasterDataRecord<ITemplateMaster>>
    {
        public const string c_DataPath = "Data/Template";

        [Serializable]
        public class Record : IMasterDataRecord<ITemplateMaster>, ITemplateMaster
        {
            public Record(int index, string id)
            {
                m_Index = index;
                m_Id = id;
            }

            [SerializeField] int m_Index;
            [SerializeField] string m_Id;
            [SerializeField] string m_FakeDescription;


            public int Index => m_Index;
            public string Id => m_Id;
            public string FakeDescription => m_FakeDescription;

            public ITemplateMaster GetMaster() => this;

#if UNITY_EDITOR
            public string SettableDescription { set => m_FakeDescription = value; }

#endif
        }
    }
}