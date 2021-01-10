using System.Collections.ObjectModel;
using YamlDotNet.Core.Tokens;

namespace YamlDotNet.Core
{
	public class TagDirectiveCollection : KeyedCollection<string, TagDirective>
	{
		protected override string GetKeyForItem(TagDirective item)
		{
			return default(string);
		}

	}
}
