using YamlDotNet.Serialization;

namespace YamlDotNet.Serialization.ObjectGraphVisitors
{
	public class AnchorAssigningObjectGraphVisitor : ChainedObjectGraphVisitor
	{
		public AnchorAssigningObjectGraphVisitor(IObjectGraphVisitor nextVisitor, IEventEmitter eventEmitter, IAliasProvider aliasProvider) : base(default(IObjectGraphVisitor))
		{
		}

	}
}
