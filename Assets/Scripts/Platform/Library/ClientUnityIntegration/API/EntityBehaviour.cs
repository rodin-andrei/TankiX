using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class EntityBehaviour : MonoBehaviour
	{
		[SerializeField]
		public string template;
		[SerializeField]
		private int templateIdLow;
		[SerializeField]
		private int templateIdHigh;
		public string configPath;
		public bool handleAutomaticaly;
	}
}
