using System;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class IllegalCombineException : Exception
	{
		public IllegalCombineException(Handler handler, ArgumentNode argumentNode)
		{
		}

	}
}
