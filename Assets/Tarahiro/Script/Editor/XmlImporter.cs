using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;
using UnityEditor;
using Tarahiro.MasterData;

namespace Tarahiro.Editor.XmlImporter
{
#if UNITY_EDITOR
	/// <summary>
	/// Xmlをインポートするための共通処理を実装したクラスです。
	/// </summary>
	public static class XmlImporter
    {
		class Workbook : IWorkbook
		{
			public Workbook(string path)
			{
				XNamespace o = "urn:schemas-microsoft-com:office:office";
				XNamespace x = "urn:schemas-microsoft-com:office:excel";
				XNamespace ss = "urn:schemas-microsoft-com:office:spreadsheet";

				using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (var stream = new StreamReader(fileStream))
					{
						var worksheets = new List<IWorksheet>();

						var rootElement = XElement.Load(stream);
						foreach (var worksheetElement in rootElement.Elements(ss + "Worksheet"))
						{
							worksheets.Add(new Worksheet(worksheetElement));
						}

						Path = path;
						Worksheets = worksheets;
					}
				}
			}

			public string Path { get; }
			public IEnumerable<IWorksheet> Worksheets { get; }
		}

		class Worksheet : IWorksheet
		{
			readonly string[,] m_Cells;

			public Worksheet(XElement worksheetElement)
			{
				XNamespace o = "urn:schemas-microsoft-com:office:office";
				XNamespace x = "urn:schemas-microsoft-com:office:excel";
				XNamespace ss = "urn:schemas-microsoft-com:office:spreadsheet";

				var tableElement = worksheetElement.Element(ss + "Table");
				var width = int.Parse(tableElement.Attribute(ss + "ExpandedColumnCount").Value);
				var height = int.Parse(tableElement.Attribute(ss + "ExpandedRowCount").Value);
				var cells = new string[height, width];

				var row = 0;
				foreach (var rowElement in tableElement.Elements(ss + "Row"))
				{
					var rowIndexAttribute = rowElement.Attribute(ss + "Index");
					if (rowIndexAttribute != null)
					{
						row = int.Parse(rowIndexAttribute.Value) - 1;
					}

					var column = 0;
					foreach (var cellElement in rowElement.Elements(ss + "Cell"))
					{
						var cellIndexAttribute = cellElement.Attribute(ss + "Index");
						if (cellIndexAttribute != null)
						{
							column = int.Parse(cellIndexAttribute.Value) - 1;
						}

						var dataElement = cellElement.Element(ss + "Data");
						if (dataElement != null)
						{
							cells[row, column] = dataElement.Value;
						}

						++column;
					}

					++row;
				}

				Name = worksheetElement.Attribute(ss + "Name").Value;
				m_Cells = cells;
			}

			public string Name { get; }
			public int Width { get { return m_Cells.GetLength(1); } }
			public int Height { get { return m_Cells.GetLength(0); } }
			public TableCell this[int row, int column] { get { return new TableCell(m_Cells[row, column]); } }
		}

		// ワークブックをインポート（pathはUnityプロジェクトフォルダからの相対パス）
		public static IWorkbook ImportWorkbook(string path)
		{
			return new Workbook(path);
		}


		// 辞書をアセットにエクスポート
		public static bool ExportOrderedDictionary<TTable, TData, TInterface>(string resourceDataPath, IReadOnlyList<TData> records)
			where TTable : MasterDataOrderedDictionary<TData, TInterface>
			where TInterface : IIndexable, IIdentifiable
			where TData : IIndexable, IIdentifiable, TInterface
		{
            // IDの重複チェック
            HashSet<string> ids = new HashSet<string>();
            foreach (var record in records)
            {
                if (ids.Contains(record.Id))
                {
                    Log.DebugAssert($"キー: {record.Id} が重複しています。");
                    return false;
                }
                ids.Add(record.Id);
            }

			string path = "Assets/Resources/" + resourceDataPath + ".asset";
			var asset = AssetDatabase.LoadAssetAtPath<TTable>(path);
			// 存在しなかったら作成
			if (asset == null)
			{
				var directoryPath = Path.GetDirectoryName(path);

				// フォルダがなければ生成
				if (!Directory.Exists(directoryPath))
				{
					Directory.CreateDirectory(directoryPath);
				}

				asset = ScriptableObject.CreateInstance<TTable>();
				AssetDatabase.CreateAsset(asset, path);
			}

			asset.SettableRecords = records;
			asset.hideFlags = HideFlags.NotEditable;

			EditorUtility.SetDirty(asset);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();

            return true;
		}

		// 置換した数値を取得
		public static int GetReplacedValue(Dictionary<string, int> dictionary, IWorksheet sheet, int x, int y)
		{
			string origin = sheet[x, y].String;
			if (origin.Length > 0 && dictionary.ContainsKey(origin))
			{
				return dictionary[origin];
			}
			Log.DebugWarning("置換キー： " + origin + " が見つかりませんでした。");
			return 0;
		}
	}
#endif
}
