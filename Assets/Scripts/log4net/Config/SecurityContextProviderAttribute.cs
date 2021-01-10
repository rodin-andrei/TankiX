using System;

namespace log4net.Config
{
	[Serializable]
	public class SecurityContextProviderAttribute : ConfiguratorAttribute
	{
		public SecurityContextProviderAttribute(Type providerType) : base(default(int))
		{
		}

	}
}
