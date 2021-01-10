using YamlDotNet.Core;

namespace YamlDotNet.Core.Events
{
	public class Comment : ParsingEvent
	{
		public Comment(string value, bool isInline) : base(default(Mark), default(Mark))
		{
		}

	}
}
