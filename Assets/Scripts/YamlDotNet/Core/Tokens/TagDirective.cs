using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class TagDirective : Token
	{
		public TagDirective(string handle, string prefix) : base(default(Mark), default(Mark))
		{
		}

	}
}
