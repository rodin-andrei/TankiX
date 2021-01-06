using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class FromConfigBehaviour : ECSBehaviour
	{
		[SerializeField]
		private string configPath;
		[SerializeField]
		private string yamlKey;
	}
}
