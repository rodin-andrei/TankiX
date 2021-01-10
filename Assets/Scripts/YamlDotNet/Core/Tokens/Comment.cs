using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class Comment : Token
	{
		public Comment(string value, bool isInline) : base(default(Mark), default(Mark))
		{
		}

	}
}
