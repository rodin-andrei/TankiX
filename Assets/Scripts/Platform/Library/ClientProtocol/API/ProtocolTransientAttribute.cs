using System;

namespace Platform.Library.ClientProtocol.API
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ProtocolTransientAttribute : Attribute
	{
		public int MinimalServerProtocolVersion
		{
			get;
			set;
		}

		public ProtocolTransientAttribute()
		{
			MinimalServerProtocolVersion = int.MaxValue;
		}

		public ProtocolTransientAttribute(int minimalServerProtocolVersion)
		{
			MinimalServerProtocolVersion = minimalServerProtocolVersion;
		}
	}
}
