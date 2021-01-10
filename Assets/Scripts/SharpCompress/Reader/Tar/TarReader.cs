using SharpCompress.Reader;
using SharpCompress.Common.Tar;
using System.IO;
using SharpCompress.Common;

namespace SharpCompress.Reader.Tar
{
	public class TarReader : AbstractReader<TarEntry, TarVolume>
	{
		internal TarReader(Stream stream, CompressionType compressionType, Options options)
		{
		}

	}
}
