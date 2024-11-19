using Tarahiro;
using Tarahiro.MasterData;
using System;
using System.Collections;
using UnityEngine;
using Tarahiro.OtherGame;

namespace Tarahiro.OtherGame.MasterData
{
    //---プロジェクト作成時にやること---//
    //namespaceの"project"部分を変更。（gaw[yymmdd].Modelとか）

    //---クラス作成時にやること---//
    //"Template" を置換
    //ITemplateMasterに合わせてフィールドを追加
    public class OtherGameMasterData : MasterDataOrderedDictionary<OtherGameMasterData.Record, IMasterDataRecord<IOtherGameMaster>>
    {
        public const string c_DataPath = "Data/OtherGame";

        [Serializable]
        public class Record : IMasterDataRecord<IOtherGameMaster>, IOtherGameMaster
        {
            public Record(int index, string id)
            {
                m_Index = index;
                m_Id = id;
            }

            [SerializeField] int m_Index;
            [SerializeField] string m_Id;
            [SerializeField] string m_CodeName;
            [SerializeField] string m_TitleNameJp;
            [SerializeField] string m_TitleNameEn;
            [SerializeField] string m_GenreNameJp;
            [SerializeField] string m_GenreNameEn;
            [SerializeField] string m_DescriptionJp;
            [SerializeField] string m_DescriptionEn;
            [SerializeField] string m_IconPathJp;
            [SerializeField] string m_IconPathEn;
            [SerializeField] string m_ScreenShotCenterPathJp;
            [SerializeField] string m_ScreenShotCenterPathEn;
            [SerializeField] string m_ScreenShotRightTopPathJp;
            [SerializeField] string m_ScreenShotRightTopPathEn;
            [SerializeField] string m_ScreenShotRightBottomPathJp;
            [SerializeField] string m_ScreenShotRightBottomPathEn;
            [SerializeField] string m_StoreUrlJp;
            [SerializeField] string m_StoreUrlEn;

            public int Index => m_Index;
            public string Id => m_Id;
            public string CodeName => m_CodeName;
            public string TitleNameJp => m_TitleNameJp;
            public string TitleNameEn => m_TitleNameEn;
            public string GenreNameJp => m_GenreNameJp;
            public string GenreNameEn => m_GenreNameEn;
            public string DescriptionJp => m_DescriptionJp;
            public string DescriptionEn => m_DescriptionEn;
            public string IconPathEn => m_IconPathEn;
            public string IconPathJp => m_IconPathJp;
            public string ScreenShotCenterPathJp => m_ScreenShotCenterPathJp;
            public string ScreenShotCenterPathEn => m_ScreenShotCenterPathEn;
            public string ScreenShotRightTopPathJp => m_ScreenShotRightTopPathJp;
            public string ScreenShotRightTopPathEn => m_ScreenShotRightTopPathEn;
            public string ScreenShotRightBottomPathJp => m_ScreenShotRightBottomPathJp;
            public string ScreenShotRightBottomPathEn => m_ScreenShotRightBottomPathEn;
            public string StoreUrlJp => m_StoreUrlJp;
            public string StoreUrlEn => m_StoreUrlEn;

            public IOtherGameMaster GetMaster() => this;

#if UNITY_EDITOR  
            public string SettableCodeName { set => m_CodeName = value; }
            public string SettableTitleNameJp { set => m_TitleNameJp = value; }
            public string SettableGenreNameJp { set => m_GenreNameJp = value; }
            public string SettableDescriptionJp { set => m_DescriptionJp = value; }
            public string SettableIconPathJp { set => m_IconPathJp = value; }
            public string SettableScreenShotCenterPathJp { set => m_ScreenShotCenterPathJp = value; }
            public string SettableScreenShotRightTopPathJp { set => m_ScreenShotRightTopPathJp = value; }
            public string SettableScreenShotRightBottomPathJp { set => m_ScreenShotRightBottomPathJp = value; }
            public string SettableStoreUrlJp { set => m_StoreUrlJp = value; }
            public string SettableTitleNameEn { set => m_TitleNameEn = value; }
            public string SettableGenreNameEn { set => m_GenreNameEn = value; }
            public string SettableDescriptionEn { set => m_DescriptionEn = value; }
            public string SettableIconPathEn { set => m_IconPathEn = value; }
            public string SettableScreenShotCenterPathEn { set => m_ScreenShotCenterPathEn = value; }
            public string SettableScreenShotRightTopPathEn { set => m_ScreenShotRightTopPathEn = value; }
            public string SettableScreenShotRightBottomPathEn { set => m_ScreenShotRightBottomPathEn = value; }
            public string SettableStoreUrlEn { set => m_StoreUrlEn = value; }

#endif
        }
    }
}