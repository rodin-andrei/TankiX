using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.API
{
	public class OverrideConfigPathAttribute : Attribute
	{
		public OverrideConfigPathAttribute(string configPath, PathOverrideType overrideType)
		{
		}

	}
}
