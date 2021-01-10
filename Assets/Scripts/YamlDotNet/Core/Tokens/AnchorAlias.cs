using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class AnchorAlias : Token
	{
		public AnchorAlias(string value) : base(default(Mark), default(Mark))
		{
		}

	}
}
