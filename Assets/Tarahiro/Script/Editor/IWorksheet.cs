namespace Tarahiro.Editor.XmlImporter
{
	public interface IWorksheet
	{
		string Name { get; }

		int Width { get; }
		int Height { get; }

		TableCell this[int row, int column] { get; }
	}
}
