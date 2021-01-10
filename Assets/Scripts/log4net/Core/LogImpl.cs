namespace log4net.Core
{
	public class LogImpl : LoggerWrapperImpl
	{
		public LogImpl(ILogger logger) : base(default(ILogger))
		{
		}

	}
}
