using log4net.Core;

namespace log4net.Repository.Hierarchy
{
	public class RootLogger : Logger
	{
		public RootLogger(Level level) : base(default(string))
		{
		}

	}
}
