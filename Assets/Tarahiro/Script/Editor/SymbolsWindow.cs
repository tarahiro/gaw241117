using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEditor;
using UnityEngine;

namespace Tarahiro.Editor.Symbols
{
#if UNITY_EDITOR
	/// <summary>
	/// シンボルを設定するウィンドウクラスです。
	/// </summary>
	internal class SymbolsWindow : UnityEditor.EditorWindow
	{
		/// <summary>
		/// シンボルのデータを管理するクラス
		/// </summary>
		private class SymbolData
		{
			public string Name { get; private set; }   // 定義名を返します
			public string Comment { get; private set; }   // コメントを返します
			public bool IsEnable { get; set; }   // 有効かどうかを取得または設定します

			/// <summary>
			/// コンストラクタ
			/// </summary>
			public SymbolData(XmlNode node)
			{
				Name = node.Attributes["name"].Value;
				Comment = node.Attributes["comment"].Value;
			}
		}

		// 定数
		private const string c_XmlPath = "ImportData/Editor/symbols.xml";  // 読み込む .xml のファイルパス

		/// <summary>
		/// ウィンドウを開く
		/// </summary>
		[MenuItem("Tarahiro/Symbols", priority = (int)EditorConst.CategoryMenuItemPriority.Symbols)]
		private static void OpenWindow()
		{
			var window = GetWindow<SymbolsWindow>(true, "Symbols");
			window.Init();
		}

		private static Vector2 mScrollPos;     // スクロール座標
		private static SymbolData[] mSymbolList;    // シンボルのリスト

		private void Init()
		{
			var document = new XmlDocument();
			document.Load(c_XmlPath);

			var root = document.GetElementsByTagName("root")[0];
			var symbolList = new List<XmlNode>();

			foreach (XmlNode n in root.ChildNodes)
			{
				if (n.Name == "symbol")
				{
					symbolList.Add(n);
				}
			}

			mSymbolList = symbolList
				.Select(c => new SymbolData(c))
				.ToArray();

			var defineSymbols = PlayerSettings
				.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup)
				.Split(';');

			foreach (var n in mSymbolList)
			{
				n.IsEnable = defineSymbols.Any(c => c == n.Name);
			}
		}

		private void OnGUI()
		{
			EditorGUILayout.BeginVertical();
			mScrollPos = EditorGUILayout.BeginScrollView(
				mScrollPos,
				GUILayout.Height(position.height)
			);
			foreach (var n in mSymbolList)
			{
				EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
				n.IsEnable = EditorGUILayout.Toggle(n.IsEnable, GUILayout.Width(16));
				if (GUILayout.Button("Copy"))
				{
					EditorGUIUtility.systemCopyBuffer = n.Name;
				}
				EditorGUILayout.LabelField(n.Name, GUILayout.ExpandWidth(true), GUILayout.MinWidth(0));
				EditorGUILayout.LabelField(n.Comment, GUILayout.ExpandWidth(true), GUILayout.MinWidth(0));
				EditorGUILayout.EndHorizontal();
			}
			if (GUILayout.Button("Save"))
			{
				var defineSymbols = mSymbolList
					.Where(c => c.IsEnable)
					.Select(c => c.Name)
					.ToArray();

				PlayerSettings.SetScriptingDefineSymbolsForGroup(
					EditorUserBuildSettings.selectedBuildTargetGroup,
					string.Join(";", defineSymbols)
				);
				Close();
			}
			EditorGUILayout.EndScrollView();
			EditorGUILayout.EndVertical();
		}
	}
#endif
}
