using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class VersionDirective : Token
	{
		public VersionDirective(Version version) : base(default(Mark), default(Mark))
		{
		}

	}
}
