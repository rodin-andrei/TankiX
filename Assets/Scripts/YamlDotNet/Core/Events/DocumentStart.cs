using YamlDotNet.Core;

namespace YamlDotNet.Core.Events
{
	public class DocumentStart : ParsingEvent
	{
		public DocumentStart() : base(default(Mark), default(Mark))
		{
		}

	}
}
