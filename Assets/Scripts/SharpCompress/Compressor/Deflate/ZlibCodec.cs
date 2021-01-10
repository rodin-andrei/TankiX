namespace SharpCompress.Compressor.Deflate
{
	internal class ZlibCodec
	{
		public byte[] InputBuffer;
		public int NextIn;
		public int AvailableBytesIn;
		public long TotalBytesIn;
		public byte[] OutputBuffer;
		public int NextOut;
		public int AvailableBytesOut;
		public long TotalBytesOut;
		public string Message;
		public CompressionLevel CompressLevel;
		public int WindowBits;
		public CompressionStrategy Strategy;
	}
}
