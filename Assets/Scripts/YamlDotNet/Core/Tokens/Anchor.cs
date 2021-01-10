using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class Anchor : Token
	{
		public Anchor(string value) : base(default(Mark), default(Mark))
		{
		}

	}
}
