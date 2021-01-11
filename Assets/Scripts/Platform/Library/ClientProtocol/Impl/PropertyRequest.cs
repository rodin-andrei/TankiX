using System.Reflection;
using Platform.Library.ClientProtocol.API;

namespace Platform.Library.ClientProtocol.Impl
{
	public class PropertyRequest
	{
		public PropertyInfo PropertyInfo
		{
			get;
			private set;
		}

		public CodecInfoWithAttributes CodecInfoWithAttributes
		{
			get;
			private set;
		}

		public PropertyRequest(PropertyInfo propertyInfo, CodecInfoWithAttributes codecInfoWithAttributes)
		{
			PropertyInfo = propertyInfo;
			CodecInfoWithAttributes = codecInfoWithAttributes;
		}
	}
}
