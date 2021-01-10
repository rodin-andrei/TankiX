using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class Key : Token
	{
		public Key() : base(default(Mark), default(Mark))
		{
		}

	}
}
