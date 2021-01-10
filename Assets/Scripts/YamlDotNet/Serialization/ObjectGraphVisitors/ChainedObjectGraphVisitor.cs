using YamlDotNet.Serialization;

namespace YamlDotNet.Serialization.ObjectGraphVisitors
{
	public class ChainedObjectGraphVisitor
	{
		protected ChainedObjectGraphVisitor(IObjectGraphVisitor nextVisitor)
		{
		}

	}
}
