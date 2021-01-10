using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class Value : Token
	{
		public Value() : base(default(Mark), default(Mark))
		{
		}

	}
}
