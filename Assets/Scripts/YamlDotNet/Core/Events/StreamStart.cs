using YamlDotNet.Core;

namespace YamlDotNet.Core.Events
{
	public class StreamStart : ParsingEvent
	{
		public StreamStart() : base(default(Mark), default(Mark))
		{
		}

	}
}
