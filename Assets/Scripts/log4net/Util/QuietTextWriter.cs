using System.IO;
using log4net.Core;

namespace log4net.Util
{
	public class QuietTextWriter : TextWriterAdapter
	{
		public QuietTextWriter(TextWriter writer, IErrorHandler errorHandler) : base(default(TextWriter))
		{
		}

	}
}
