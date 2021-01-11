using System;
using System.Linq;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine.Profiling;

namespace Platform.Library.ClientUnityIntegration.Impl
{
	public static class UnityProfiler
	{
		public static void Listen()
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			if (commandLineArgs != null && commandLineArgs.Any((string arg) => "-profiler".Equals(arg)))
			{
				UnityEngine.Profiling.Profiler.enabled = true;
			}
			Platform.Kernel.OSGi.ClientCore.API.Profiler.OnBeginSample -= OnBeginSample;
			Platform.Kernel.OSGi.ClientCore.API.Profiler.OnBeginSample += OnBeginSample;
			Platform.Kernel.OSGi.ClientCore.API.Profiler.OnEndSample -= OnEndSample;
			Platform.Kernel.OSGi.ClientCore.API.Profiler.OnEndSample += OnEndSample;
		}

		public static void OnBeginSample(string name)
		{
		}

		public static void OnEndSample()
		{
		}
	}
}
