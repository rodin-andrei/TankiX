using System.IO;

namespace Platform.Library.ClientProtocol.Impl
{
	public abstract class StreamData
	{
		private bool hasReader;

		private bool hasWriter;

		private BigEndianBinaryReader reader;

		private BigEndianBinaryWriter writer;

		public abstract Stream Stream
		{
			get;
		}

		public BigEndianBinaryReader Reader
		{
			get
			{
				if (hasReader)
				{
					return reader;
				}
				reader = new BigEndianBinaryReader(Stream);
				hasReader = true;
				return reader;
			}
		}

		public BigEndianBinaryWriter Writer
		{
			get
			{
				if (hasWriter)
				{
					return writer;
				}
				writer = new BigEndianBinaryWriter(Stream);
				hasWriter = true;
				return writer;
			}
		}

		public long Length
		{
			get
			{
				return Stream.Length;
			}
		}

		public long Position
		{
			get
			{
				return Stream.Position;
			}
			set
			{
				Stream.Position = value;
			}
		}

		protected StreamData()
		{
			hasReader = false;
			hasWriter = false;
		}

		public void SetLength(long value)
		{
			Stream.SetLength(value);
		}

		public void Write(byte[] buffer, int offset, int count)
		{
			Stream.Write(buffer, offset, count);
		}

		public void WriteByte(byte value)
		{
			Stream.WriteByte(value);
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return Stream.Read(buffer, offset, count);
		}

		public void Flip()
		{
			Stream.Seek(0L, SeekOrigin.Begin);
		}

		public void Clear()
		{
			Flip();
			SetLength(0L);
		}
	}
	public abstract class StreamData<T> : StreamData where T : Stream, new()
	{
		private T streamData;

		public override Stream Stream
		{
			get
			{
				return streamData;
			}
		}

		public T CastedStream
		{
			get
			{
				return streamData;
			}
		}

		protected StreamData()
		{
			streamData = new T();
		}
	}
}
