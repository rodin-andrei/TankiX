using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class FlowSequenceStart : Token
	{
		public FlowSequenceStart() : base(default(Mark), default(Mark))
		{
		}

	}
}
