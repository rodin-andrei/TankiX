using System.IO;

namespace log4net.Util
{
	public class ProtectCloseTextWriter : TextWriterAdapter
	{
		public ProtectCloseTextWriter(TextWriter writer) : base(default(TextWriter))
		{
		}

	}
}
