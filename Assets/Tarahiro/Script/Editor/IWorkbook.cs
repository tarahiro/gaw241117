using System.Collections.Generic;

namespace Tarahiro.Editor.XmlImporter
{
	public interface IWorkbook
	{
		string Path { get; }

		IEnumerable<IWorksheet> Worksheets { get; }
	}
}
