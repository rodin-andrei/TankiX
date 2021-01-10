using SharpCompress.Common.Tar;
using SharpCompress.Common;

namespace SharpCompress.Archive.Tar
{
	public class TarArchiveEntry : TarEntry
	{
		internal TarArchiveEntry(TarArchive archive, TarFilePart part, CompressionType compressionType) : base(default(TarFilePart), default(CompressionType))
		{
		}

	}
}
