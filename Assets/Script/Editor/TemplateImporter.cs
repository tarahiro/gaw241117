using System.Collections;
using UnityEngine;
using Tarahiro;
using Tarahiro.MasterData;
using Tarahiro.Editor.XmlImporter;
using System.Collections.Generic;
using UnityEditor;
using FakeProject;
using FakeProject.MasterData;

namespace FakeProject.Editor
{
#if UNITY_EDITOR
    //---プロジェクト作成時にやること---//
    //namespaceの"FakeProject"部分を変更。（gaw[yymmdd]とか）
    //アセンブリ構成に応じて、using部分を追加（gaw[yymmdd].model,gaw[yymmdd].Model.MasterData 等 ）

    //---クラス作成時にやること---//
    //"Template" を置換
    //ITemplateMasterに合わせてフィールドを追加
    internal sealed class TemplateImporter
    {
        const string c_XmlPath = "ImportData/Template/Template.xml";
        const string c_SheetName = "Script";
        enum Columns
        {
            Index = 0,
            Id = 1,
            Description = 2,
        }

        //--------------------------------------------------------------------
        // 読み込み
        //--------------------------------------------------------------------

        [MenuItem("Assets/Tables/Import Template", false, 2)]
        static void ImportMenuTemplate()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            Import();

            stopwatch.Stop();
            Log.DebugLog($"Template imported in {stopwatch.ElapsedMilliseconds / 1000.0f} seconds.");
        }

        public static void Import()
        {
            var book = XmlImporter.ImportWorkbook(c_XmlPath);

            var TemplateDataList = new List<TemplateMasterData.Record>();

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
                        TemplateDataList.Add(new TemplateMasterData.Record(index, id)
                        {
                            SettableDescription = sheet[row, (int)Columns.Description].String,
                        });
                    }
                }
            }

            // データ出力
            XmlImporter.ExportOrderedDictionary<TemplateMasterData, TemplateMasterData.Record, IMasterDataRecord<ITemplateMaster>>(TemplateMasterData.c_DataPath, TemplateDataList);
        }
    }
#endif
}