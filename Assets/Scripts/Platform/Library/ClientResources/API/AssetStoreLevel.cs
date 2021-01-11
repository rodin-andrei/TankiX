using System.ComponentModel;

namespace Platform.Library.ClientResources.API
{
	[DefaultValue(AssetStoreLevel.MANAGED)]
	public enum AssetStoreLevel
	{
		NONE,
		MANAGED,
		STATIC
	}
}
