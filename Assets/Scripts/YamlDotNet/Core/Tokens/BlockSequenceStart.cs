using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class BlockSequenceStart : Token
	{
		public BlockSequenceStart() : base(default(Mark), default(Mark))
		{
		}

	}
}
