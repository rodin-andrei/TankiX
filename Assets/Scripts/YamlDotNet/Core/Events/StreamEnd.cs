using YamlDotNet.Core;

namespace YamlDotNet.Core.Events
{
	public class StreamEnd : ParsingEvent
	{
		public StreamEnd() : base(default(Mark), default(Mark))
		{
		}

	}
}
