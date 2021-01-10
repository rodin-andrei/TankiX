using SharpCompress.Common;
using System.IO;

namespace SharpCompress.Common.Tar
{
	public class TarVolume : GenericVolume
	{
		public TarVolume(Stream stream, Options options) : base(default(Stream), default(Options))
		{
		}

	}
}
