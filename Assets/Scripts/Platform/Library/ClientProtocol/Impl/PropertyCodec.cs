using System.Reflection;
using Platform.Library.ClientProtocol.API;

namespace Platform.Library.ClientProtocol.Impl
{
	public class PropertyCodec
	{
		public Codec Codec
		{
			get;
			private set;
		}

		public PropertyInfo PropertyInfo
		{
			get;
			private set;
		}

		public PropertyCodec(Codec codec, PropertyInfo propertyInfo)
		{
			Codec = codec;
			PropertyInfo = propertyInfo;
		}
	}
}
