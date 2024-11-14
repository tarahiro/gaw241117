namespace Tarahiro.Editor.XmlImporter
{
	public class TableCell
	{
		string m_Content;

		public TableCell(string content)
		{
			m_Content = content;
		}

		// 文字列を取得
		public string String { get { return m_Content; } }

		// 整数を取得
		public int Int
		{
			get
			{
				return IsEmpty ? 0 : int.Parse(m_Content);
			}
		}

		// 浮動小数点数を取得
		public float Float
		{
			get
			{
				return IsEmpty ? 0.0f : float.Parse(m_Content);
			}
		}

		// フラグを取得（空欄じゃなけれればtrue）
		public bool Bool => !IsEmpty;

		// 空欄かどうか取得
		public bool IsEmpty { get { return string.IsNullOrEmpty(m_Content); } }
	}
}
