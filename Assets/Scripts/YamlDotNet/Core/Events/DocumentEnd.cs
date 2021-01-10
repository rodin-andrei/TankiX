using YamlDotNet.Core;

namespace YamlDotNet.Core.Events
{
	public class DocumentEnd : ParsingEvent
	{
		public DocumentEnd(bool isImplicit) : base(default(Mark), default(Mark))
		{
		}

	}
}
