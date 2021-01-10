using System.IO;
using System.Text;

namespace log4net.Util
{
	public class TextWriterAdapter : TextWriter
	{
		protected TextWriterAdapter(TextWriter writer)
		{
		}

		public override Encoding Encoding
		{
			get { return default(Encoding); }
		}

	}
}
