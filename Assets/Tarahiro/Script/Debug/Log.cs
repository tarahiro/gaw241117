using UnityEngine;
using System.Diagnostics;

namespace Tarahiro
{
	public class Log
	{
		[Conditional("ENABLE_DEBUG")]
		public static void AssertReferenceOnSerialize(GameObject gameObject, string name, Object field)
		{
			UnityEngine.Debug.Assert(field != null, gameObject.name + ": " + name + " はnull以外のSerializeが必要です。");
		}

		[Conditional("ENABLE_DEBUG")]
		public static void AssertReferenceOnAwake<T>(GameObject gameObject, string name, T field)
		{
			UnityEngine.Debug.Assert(field != null, gameObject.name + ": " + name + " のAwake時の参照取得に失敗しました。");
		}

		// DEBUG時のみログを流す
		[Conditional("ENABLE_DEBUG")]
		public static void DebugLog(object message)
		{
			UnityEngine.Debug.Log(message);
		}

		// DEBUG時のみ警告を流す
		[Conditional("ENABLE_DEBUG")]
		public static void DebugWarning(bool properCondition, string str)
		{
			if (properCondition == false)
			{
				UnityEngine.Debug.LogWarning(str);
			}
		}
		[Conditional("ENABLE_DEBUG")]
		public static void DebugWarning(string str)
		{
			UnityEngine.Debug.LogWarning(str);
		}

		// DEBUG時のみAssertionを流す
		[Conditional("ENABLE_DEBUG")]
		public static void DebugAssert(bool properCondition)
		{
			UnityEngine.Debug.Assert(properCondition);
		}
		[Conditional("ENABLE_DEBUG")]
		public static void DebugAssert(bool properCondition, string str)
		{
			if (properCondition == false)
			{
				UnityEngine.Debug.LogAssertion(str);
			}
		}
		[Conditional("ENABLE_DEBUG")]
		public static void DebugAssert(string str)
		{
			UnityEngine.Debug.LogAssertion(str);
		}

		// TEST時のみログを流す
		[Conditional("UNITY_INCLUDE_TESTS")]
		public static void TestLog(string str)
		{
			UnityEngine.Debug.Log(str);
		}

		// TEST時のみAssertを流す
		[Conditional("UNITY_INCLUDE_TESTS")]
		public static void TestAssert(bool properCondition)
		{
			UnityEngine.Debug.Assert(properCondition);
		}
	}
}
