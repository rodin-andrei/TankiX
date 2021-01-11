using System;
using System.IO;
using Platform.Library.ClientProtocol.Impl;

namespace Platform.Library.ClientProtocol.API
{
	public class ProtocolBuffer
	{
		public IOptionalMap OptionalMap
		{
			get;
			private set;
		}

		public MemoryStreamData Data
		{
			get;
			private set;
		}

		public BinaryReader Reader
		{
			get
			{
				return Data.Reader;
			}
		}

		public BinaryWriter Writer
		{
			get
			{
				return Data.Writer;
			}
		}

		public ProtocolBuffer()
			: this(new OptionalMap(), new MemoryStreamData())
		{
		}

		public ProtocolBuffer(IOptionalMap optionalMap, MemoryStreamData stream)
		{
			OptionalMap = optionalMap;
			Data = stream;
		}

		public override string ToString()
		{
			string text = StreamDumper.Dump(Data.Stream);
			text += Environment.NewLine;
			text += OptionalMap.ToString();
			return text + Environment.NewLine;
		}

		public void Flip()
		{
			Data.Flip();
		}

		public void Clear()
		{
			OptionalMap.Clear();
			Data.Clear();
		}
	}
}
