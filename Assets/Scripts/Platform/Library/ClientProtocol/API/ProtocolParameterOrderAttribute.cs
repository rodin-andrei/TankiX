using System;

namespace Platform.Library.ClientProtocol.API
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ProtocolParameterOrderAttribute : Attribute
	{
		public int Order
		{
			get;
			set;
		}

		public ProtocolParameterOrderAttribute(int order)
		{
			Order = order;
		}
	}
}
