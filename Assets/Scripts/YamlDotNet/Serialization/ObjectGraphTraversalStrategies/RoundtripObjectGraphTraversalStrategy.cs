using YamlDotNet.Serialization;

namespace YamlDotNet.Serialization.ObjectGraphTraversalStrategies
{
	public class RoundtripObjectGraphTraversalStrategy : FullObjectGraphTraversalStrategy
	{
		public RoundtripObjectGraphTraversalStrategy(Serializer serializer, ITypeInspector typeDescriptor, ITypeResolver typeResolver, int maxRecursion) : base(default(Serializer), default(ITypeInspector), default(ITypeResolver), default(int), default(INamingConvention))
		{
		}

	}
}
