using System.IO;

namespace Platform.Library.ClientProtocol.Impl
{
	public class MemoryStreamData : StreamData<MemoryStream>
	{
		public byte[] GetBuffer()
		{
			return base.CastedStream.GetBuffer();
		}
	}
}
