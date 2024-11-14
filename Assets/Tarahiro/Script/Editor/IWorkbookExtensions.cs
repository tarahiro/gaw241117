using System.Collections.Generic;
using System.Linq;

namespace Tarahiro.Editor.XmlImporter
{
	public static class IWorkbookExtensions
	{
		public static IWorksheet TryGetWorksheet(this IWorkbook book, string sheetName)
		{
			return book.Worksheets.FirstOrDefault(sheet => sheet.Name == sheetName);
		}

		// 置換リストを取得
		public static Dictionary<string, int> GetReplaceDictionary(this IWorkbook book)
		{
			Dictionary<string, int> replaceDictionary = new Dictionary<string, int>();

			IWorksheet sheet = book.TryGetWorksheet("置換");
			if (sheet != null)
			{
				for (int row = 0; row < sheet.Height; ++row)
				{
					// どちらかが空ならスキップ
					if (sheet[row, 0].IsEmpty || sheet[row, 1].IsEmpty)
					{
						continue;
					}

					replaceDictionary.Add(sheet[row, 0].String, sheet[row, 1].Int);
				}
			}

			return replaceDictionary;
		}
	}
}
