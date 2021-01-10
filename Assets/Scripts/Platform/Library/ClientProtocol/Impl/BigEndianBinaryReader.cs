using System.IO;

namespace Platform.Library.ClientProtocol.Impl
{
	public class BigEndianBinaryReader : BinaryReader
	{
		public BigEndianBinaryReader(Stream input) : base(default(Stream))
		{
		}

	}
}
