using YamlDotNet.Serialization;

namespace YamlDotNet.Serialization.ObjectGraphVisitors
{
	public class DefaultExclusiveObjectGraphVisitor : ChainedObjectGraphVisitor
	{
		public DefaultExclusiveObjectGraphVisitor(IObjectGraphVisitor nextVisitor) : base(default(IObjectGraphVisitor))
		{
		}

	}
}
