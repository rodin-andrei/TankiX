using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class FlowMappingStart : Token
	{
		public FlowMappingStart() : base(default(Mark), default(Mark))
		{
		}

	}
}
