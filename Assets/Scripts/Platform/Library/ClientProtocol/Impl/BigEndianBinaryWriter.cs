using System.IO;

namespace Platform.Library.ClientProtocol.Impl
{
	public class BigEndianBinaryWriter : BinaryWriter
	{
		public BigEndianBinaryWriter(Stream output) : base(default(Stream))
		{
		}

	}
}
