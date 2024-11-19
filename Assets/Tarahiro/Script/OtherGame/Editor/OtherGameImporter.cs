using System.Collections;
using UnityEngine;
using Tarahiro;
using Tarahiro.MasterData;
using Tarahiro.Editor.XmlImporter;
using System.Collections.Generic;
using UnityEditor;
using Tarahiro.OtherGame;
using Tarahiro.OtherGame.MasterData;


namespace Tarahiro.OtherGame.Editor
{
#if UNITY_EDITOR
    //---プロジェクト作成時にやること---//
    //namespaceの"FakeProject"部分を変更。（gaw[yymmdd]とか）
    //アセンブリ構成に応じて、using部分を追加（gaw[yymmdd].model,gaw[yymmdd].Model.MasterData 等 ）

    //---クラス作成時にやること---//
    //"Template" を置換
    //ITemplateMasterに合わせてフィールドを追加
    internal sealed class OtherGameImporter
    {
        const string c_XmlPath = "ImportData/OtherGame/OtherGame.xml";
        const string c_SheetName = "Script";
        enum Columns
        {
            Index = 0,
            Id = 1,
            CodeName = 2,
            TitleNameJp = 3,
            TitleNameEn = 4,
            GenreNameJp = 5,
            GenreNameEn = 6,
            DescriptionJp = 7,
            DescriptionEn = 8,
            IconPathJp = 9,
            IconPathEn = 10,
            ScreenShotCenterPathJp = 11,
            ScreenShotCenterPathEn = 12,
            ScreenShotRightTopPathJp = 13,
            ScreenShotRightTopPathEn = 14,
            ScreenShotRightBottomPathJp = 15,
            ScreenShotRightBottomPathEn = 16,
            StoreUrlJp = 17,
            StoreUrlEn = 18,
        }

        //--------------------------------------------------------------------
        // 読み込み
        //--------------------------------------------------------------------

        [MenuItem("Assets/Tables/Import OtherGame", false, 2)]
        static void ImportMenuOtherGame()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            Import();

            stopwatch.Stop();
            Log.DebugLog($"OtherGame imported in {stopwatch.ElapsedMilliseconds / 1000.0f} seconds.");
        }

        public static void Import()
        {
            var book = XmlImporter.ImportWorkbook(c_XmlPath);

            var OtherGameDataList = new List<OtherGameMasterData.Record>();

            var sheet = book.TryGetWorksheet(c_SheetName);
            if (sheet == null)
            {
                Log.DebugWarning($"シート: {c_SheetName} が見つかりませんでした。");
            }
            else
            {
                for (int row = 0; row < sheet.Height; ++row)
                {
                    // Indexの欄が有効な数字だったら読み込み
                    if (int.TryParse(sheet[row, (int)Columns.Index].String, out int index))
                    {
                        string id = sheet[row, (int)Columns.Id].String;
                        OtherGameDataList.Add(new OtherGameMasterData.Record(index, id)
                        {
                            SettableCodeName = sheet[row, (int)Columns.CodeName].String,
                            SettableTitleNameJp = sheet[row, (int)Columns.TitleNameJp].String,
                            SettableTitleNameEn = sheet[row, (int)Columns.TitleNameEn].String,
                            SettableGenreNameJp = sheet[row, (int)Columns.GenreNameJp].String,
                            SettableGenreNameEn = sheet[row, (int)Columns.GenreNameEn].String,
                            SettableDescriptionJp = sheet[row, (int)Columns.DescriptionJp].String,
                            SettableDescriptionEn = sheet[row, (int)Columns.DescriptionEn].String,
                            SettableIconPathEn = sheet[row, (int)Columns.IconPathEn].String,
                            SettableIconPathJp = sheet[row, (int)Columns.IconPathJp].String,
                            SettableScreenShotCenterPathJp = sheet[row, (int)Columns.ScreenShotCenterPathJp].String,
                            SettableScreenShotCenterPathEn = sheet[row, (int)Columns.ScreenShotCenterPathEn].String,
                            SettableScreenShotRightTopPathJp = sheet[row, (int)Columns.ScreenShotRightTopPathJp].String,
                            SettableScreenShotRightTopPathEn = sheet[row, (int)Columns.ScreenShotRightTopPathEn].String,
                            SettableScreenShotRightBottomPathJp = sheet[row, (int)Columns.ScreenShotRightBottomPathJp].String,
                            SettableScreenShotRightBottomPathEn = sheet[row, (int)Columns.ScreenShotRightBottomPathEn].String,
                            SettableStoreUrlJp = sheet[row, (int)Columns.StoreUrlJp].String,
                            SettableStoreUrlEn = sheet[row, (int)Columns.StoreUrlEn].String,
                        });
                    }
                }
            }

            // データ出力
            XmlImporter.ExportOrderedDictionary<OtherGameMasterData, OtherGameMasterData.Record, IMasterDataRecord<IOtherGameMaster>>(OtherGameMasterData.c_DataPath, OtherGameDataList);
        }
    }
#endif
}