using System.Collections;
using UnityEngine;
using Tarahiro;
using Tarahiro.Editor.XmlImporter;
using Tarahiro.Sound;
using System.Collections.Generic;
using UnityEditor;
using Tarahiro.MasterData;
using System.Xml.Serialization;

namespace Tarahiro.Editor
{
#if UNITY_EDITOR
    internal sealed class SeImporter
    {
        const string c_XmlPath = "ImportData/Se/Se.xml";
        const string c_SheetName = "Script";
        enum Columns
        {
            Index = 0,
            Id = 1,
            SePath = 2,

        }

        //--------------------------------------------------------------------
        // 読み込み
        //--------------------------------------------------------------------

        [MenuItem("Assets/Tables/Import Se", false, 1)]
        static void ImportMenuSe()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            Import();

            stopwatch.Stop();
            Log.DebugLog($"Se imported in {stopwatch.ElapsedMilliseconds / 1000.0f} seconds.");
        }

        public static void Import()
        {
            var book = XmlImporter.XmlImporter.ImportWorkbook(c_XmlPath);

            var SeDataList = new List<SeMasterData.Record>();

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
                        SeDataList.Add(new SeMasterData.Record(index, id)
                        {
                            SettableSePath = sheet[row, (int)Columns.SePath].String,
                        });
                    }
                }
            }

            // データ出力
            XmlImporter.XmlImporter.ExportOrderedDictionary<SeMasterData, SeMasterData.Record, IMasterDataRecord<ISeMaster>>(SeMasterData.c_DataPath, SeDataList);
        }
    }
#endif
}