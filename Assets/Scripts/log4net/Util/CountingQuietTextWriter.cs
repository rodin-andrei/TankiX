using System.IO;
using log4net.Core;

namespace log4net.Util
{
	public class CountingQuietTextWriter : QuietTextWriter
	{
		public CountingQuietTextWriter(TextWriter writer, IErrorHandler errorHandler) : base(default(TextWriter), default(IErrorHandler))
		{
		}

	}
}
