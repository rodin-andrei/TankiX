using System;

namespace log4net.Config
{
	[Serializable]
	public class AliasDomainAttribute : AliasRepositoryAttribute
	{
		public AliasDomainAttribute(string name) : base(default(string))
		{
		}

	}
}
