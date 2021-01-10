using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class StreamEnd : Token
	{
		public StreamEnd() : base(default(Mark), default(Mark))
		{
		}

	}
}
