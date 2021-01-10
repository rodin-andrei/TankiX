using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class BlockEnd : Token
	{
		public BlockEnd() : base(default(Mark), default(Mark))
		{
		}

	}
}
