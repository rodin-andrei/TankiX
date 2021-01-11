using System;
using System.Reflection;
using Platform.Library.ClientProtocol.API;

namespace Platform.Library.ClientProtocol.Impl
{
	public class OptionalTypeCodec : NotOptionalCodec
	{
		private readonly Type type;

		private readonly CodecInfoWithAttributes elementCodecInfo;

		private readonly MethodInfo emptyMethod;

		private readonly MethodInfo ofMethod;

		private readonly MethodInfo isPresentMethod;

		private readonly MethodInfo getMethod;

		private Codec elementCodec;

		public OptionalTypeCodec(Type type, CodecInfoWithAttributes elementCodecInfo)
		{
			this.type = type;
			this.elementCodecInfo = elementCodecInfo;
			emptyMethod = type.GetMethod("empty");
			ofMethod = type.GetMethod("of");
			isPresentMethod = type.GetMethod("IsPresent");
			getMethod = type.GetMethod("Get");
		}

		public override void Init(Protocol protocol)
		{
			elementCodec = protocol.GetCodec(elementCodecInfo);
		}

		public override void Encode(ProtocolBuffer protocolBuffer, object data)
		{
			if (data != null && (bool)isPresentMethod.Invoke(data, null))
			{
				protocolBuffer.OptionalMap.Add(false);
				elementCodec.Encode(protocolBuffer, getMethod.Invoke(data, null));
			}
			else
			{
				protocolBuffer.OptionalMap.Add(true);
			}
		}

		public override object Decode(ProtocolBuffer protocolBuffer)
		{
			if (protocolBuffer.OptionalMap.Get())
			{
				return emptyMethod.Invoke(null, null);
			}
			object obj = elementCodec.Decode(protocolBuffer);
			return ofMethod.Invoke(null, new object[1]
			{
				obj
			});
		}
	}
}
