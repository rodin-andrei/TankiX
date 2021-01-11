using System.Diagnostics;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class DebugUtils
	{
		[Conditional("UNITY_EDITOR")]
		public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration, bool depthTest)
		{
			UnityEngine.Debug.DrawLine(start, end, color, duration, depthTest);
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration)
		{
			UnityEngine.Debug.DrawLine(start, end, color, duration);
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawLine(Vector3 start, Vector3 end, Color color)
		{
			UnityEngine.Debug.DrawLine(start, end, color);
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawLine(Vector3 start, Vector3 end)
		{
			UnityEngine.Debug.DrawLine(start, end);
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawRay(Vector3 start, Vector3 direction, Color color, float duration, bool depthTest)
		{
			UnityEngine.Debug.DrawRay(start, direction, color, duration, depthTest);
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawRay(Vector3 start, Vector3 direction, Color color, float duration)
		{
			UnityEngine.Debug.DrawRay(start, direction, color, duration);
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawRay(Vector3 start, Vector3 direction, Color color)
		{
			UnityEngine.Debug.DrawRay(start, direction, color);
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawRay(Vector3 start, Vector3 direction)
		{
			UnityEngine.Debug.DrawRay(start, direction);
		}
	}
}
