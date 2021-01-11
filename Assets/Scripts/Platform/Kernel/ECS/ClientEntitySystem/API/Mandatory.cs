using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.API
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	public class Mandatory : Attribute
	{
	}
}
