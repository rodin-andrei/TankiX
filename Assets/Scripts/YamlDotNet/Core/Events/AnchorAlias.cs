using YamlDotNet.Core;

namespace YamlDotNet.Core.Events
{
	public class AnchorAlias : ParsingEvent
	{
		public AnchorAlias(string value) : base(default(Mark), default(Mark))
		{
		}

	}
}
