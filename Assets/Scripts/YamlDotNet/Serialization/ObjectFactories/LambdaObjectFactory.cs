using System;

namespace YamlDotNet.Serialization.ObjectFactories
{
	public class LambdaObjectFactory
	{
		public LambdaObjectFactory(Func<Type, object> factory)
		{
		}

	}
}
