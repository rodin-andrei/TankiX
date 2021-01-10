using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class BlockEntry : Token
	{
		public BlockEntry() : base(default(Mark), default(Mark))
		{
		}

	}
}
