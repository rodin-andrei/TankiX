using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Library.ClientResources.Impl
{
	public class BaseUrlComponent : Component
	{
		public string Url
		{
			get;
			set;
		}

		public BaseUrlComponent()
		{
		}

		public BaseUrlComponent(string url)
		{
			Url = url;
		}
	}
}
