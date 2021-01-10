using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class FlowEntry : Token
	{
		public FlowEntry() : base(default(Mark), default(Mark))
		{
		}

	}
}
