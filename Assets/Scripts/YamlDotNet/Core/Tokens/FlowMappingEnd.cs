using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class FlowMappingEnd : Token
	{
		public FlowMappingEnd() : base(default(Mark), default(Mark))
		{
		}

	}
}
