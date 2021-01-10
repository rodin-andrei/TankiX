using System;
using YamlDotNet.Core;

namespace YamlDotNet.Core.Tokens
{
	[Serializable]
	public class Scalar : Token
	{
		public Scalar(string value) : base(default(Mark), default(Mark))
		{
		}

	}
}
