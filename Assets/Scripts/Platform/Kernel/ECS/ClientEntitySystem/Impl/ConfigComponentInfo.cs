using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class ConfigComponentInfo : ComponentInfo
	{
		private string keyName;

		public string KeyName
		{
			get
			{
				return keyName;
			}
			set
			{
				keyName = value;
			}
		}

		public bool ConfigOptional
		{
			get;
			private set;
		}

		public ConfigComponentInfo(string keyName, bool configOptional)
		{
			this.keyName = keyName;
			ConfigOptional = configOptional;
		}
	}
}
