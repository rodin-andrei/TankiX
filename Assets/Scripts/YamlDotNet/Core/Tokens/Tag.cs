using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class Tag : Token
	{
		public Tag(string handle, string suffix) : base(default(Mark), default(Mark))
		{
		}

	}
}
