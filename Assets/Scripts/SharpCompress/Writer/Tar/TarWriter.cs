using SharpCompress.Writer;
using System.IO;
using SharpCompress.Common;

namespace SharpCompress.Writer.Tar
{
	public class TarWriter : AbstractWriter
	{
		public TarWriter(Stream destination, CompressionInfo compressionInfo) : base(default(ArchiveType))
		{
		}

	}
}
