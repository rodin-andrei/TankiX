using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.API
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class Not : Attribute
	{
		internal readonly Type value;

		public Not(Type type)
		{
			value = type;
		}
	}
}
