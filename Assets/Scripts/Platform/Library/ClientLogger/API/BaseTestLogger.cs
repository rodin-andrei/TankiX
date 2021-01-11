using log4net;
using Platform.Kernel.OSGi.ClientCore.API;

namespace Platform.Library.ClientLogger.API
{
	public class BaseTestLogger
	{
		[Inject]
		public static ILog Log
		{
			get;
			set;
		}

		public BaseTestLogger()
		{
			LoggerProvider.Init();
		}
	}
}
