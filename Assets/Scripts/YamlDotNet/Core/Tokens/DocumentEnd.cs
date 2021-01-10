using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class DocumentEnd : Token
	{
		public DocumentEnd() : base(default(Mark), default(Mark))
		{
		}

	}
}
