using System.IO;

namespace SharpCompress.IO
{
	internal class MarkingBinaryReader : BinaryReader
	{
		public MarkingBinaryReader(Stream stream) : base(default(Stream))
		{
		}

	}
}
