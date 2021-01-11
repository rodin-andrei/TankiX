using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class ApplicationFocusBehaviour : MonoBehaviour
	{
		public static ApplicationFocusBehaviour INSTANCE;

		private bool focused = true;

		public bool Focused
		{
			get
			{
				return focused;
			}
		}

		private void Awake()
		{
			INSTANCE = this;
		}

		private void OnApplicationFocus(bool focused)
		{
			this.focused = focused;
		}
	}
}
