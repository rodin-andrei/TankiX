using YamlDotNet.Core;

namespace YamlDotNet.Core.Events
{
	public class SequenceEnd : ParsingEvent
	{
		public SequenceEnd() : base(default(Mark), default(Mark))
		{
		}

	}
}
