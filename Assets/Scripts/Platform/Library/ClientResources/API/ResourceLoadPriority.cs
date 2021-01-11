using System.ComponentModel;

namespace Platform.Library.ClientResources.API
{
	[DefaultValue(ResourceLoadPriority.USUAL)]
	public enum ResourceLoadPriority
	{
		LOW = -100,
		USUAL = 0,
		HIGH = 100
	}
}
