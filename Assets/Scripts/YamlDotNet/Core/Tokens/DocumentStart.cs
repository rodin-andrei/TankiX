using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class DocumentStart : Token
	{
		public DocumentStart() : base(default(Mark), default(Mark))
		{
		}

	}
}
