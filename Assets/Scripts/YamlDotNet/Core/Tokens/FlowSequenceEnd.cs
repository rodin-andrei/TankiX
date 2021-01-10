using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class FlowSequenceEnd : Token
	{
		public FlowSequenceEnd() : base(default(Mark), default(Mark))
		{
		}

	}
}
