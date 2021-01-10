using System.IO;
using SharpCompress.Common;
using System;
using SharpCompress.Common.Tar;

namespace SharpCompress.Archive.Tar
{
	internal class TarWritableArchiveEntry : TarArchiveEntry
	{
		internal TarWritableArchiveEntry(TarArchive archive, Stream stream, CompressionType compressionType, string path, long size, Nullable<DateTime> lastModified, bool closeStream) : base(default(TarArchive), default(TarFilePart), default(CompressionType))
		{
		}

	}
}
