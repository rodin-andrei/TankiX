using System.Collections.Generic;
using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class ComponentRemoveOrderComparer : Comparer<Type>
	{
		public override int Compare(Type x, Type y)
		{
			return default(int);
		}

	}
}
