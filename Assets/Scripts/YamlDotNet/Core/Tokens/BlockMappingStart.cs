using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class BlockMappingStart : Token
	{
		public BlockMappingStart() : base(default(Mark), default(Mark))
		{
		}

	}
}
