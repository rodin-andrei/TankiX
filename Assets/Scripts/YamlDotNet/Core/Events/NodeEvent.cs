using YamlDotNet.Core;

namespace YamlDotNet.Core.Events
{
	public class NodeEvent : ParsingEvent
	{
		protected NodeEvent(string anchor, string tag) : base(default(Mark), default(Mark))
		{
		}

	}
}
