using Tarahiro;
using Tarahiro.MasterData;
using System;
using System.Collections;
using UnityEngine;

namespace Tarahiro.Sound
{
    public class SeMasterData : MasterDataOrderedDictionary<SeMasterData.Record, IMasterDataRecord<ISeMaster>>
    {
        public const string c_DataPath = "Data/Se";

        [Serializable]
        public class Record : IMasterDataRecord<ISeMaster>, ISeMaster
        {
            public Record(int index, string id)
            {
                m_Index = index;
                m_Id = id;
            }

            [SerializeField] int m_Index;
            [SerializeField] string m_Id;
            [SerializeField] string m_SePath;


            public int Index => m_Index;
            public string Id => m_Id;
            public string SePath => m_SePath;

            public ISeMaster GetMaster() => this;

#if UNITY_EDITOR
            public string SettableSePath { set => m_SePath = value; }

#endif
        }
    }
}