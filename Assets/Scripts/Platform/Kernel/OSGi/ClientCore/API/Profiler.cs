using System;
using System.Diagnostics;

namespace Platform.Kernel.OSGi.ClientCore.API
{
	public static class Profiler
	{
		public static event Action<string> OnBeginSample;

		public static event Action OnEndSample;

		[Conditional("DEBUG")]
		public static void BeginSample(string name)
		{
			if (Profiler.OnBeginSample != null)
			{
				Profiler.OnBeginSample(name);
			}
		}

		[Conditional("DEBUG")]
		public static void EndSample()
		{
			if (Profiler.OnEndSample != null)
			{
				Profiler.OnEndSample();
			}
		}
	}
}
