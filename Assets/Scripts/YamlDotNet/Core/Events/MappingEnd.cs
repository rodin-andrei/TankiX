using YamlDotNet.Core;

namespace YamlDotNet.Core.Events
{
	public class MappingEnd : ParsingEvent
	{
		public MappingEnd() : base(default(Mark), default(Mark))
		{
		}

	}
}
