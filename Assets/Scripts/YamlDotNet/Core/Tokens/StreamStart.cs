using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class StreamStart : Token
	{
		public StreamStart() : base(default(Mark), default(Mark))
		{
		}

	}
}
