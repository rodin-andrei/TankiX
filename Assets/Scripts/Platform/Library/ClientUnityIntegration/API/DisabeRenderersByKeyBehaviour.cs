using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class DisabeRenderersByKeyBehaviour : MonoBehaviour
	{
		public KeyCode keyKode;

		private Renderer[] disabledRenderers = new Renderer[0];

		private bool renderersDisabled;

		private void Update()
		{
			if (Input.GetKeyDown(keyKode))
			{
				renderersDisabled = !renderersDisabled;
			}
			if (renderersDisabled)
			{
				DisableRenderers();
			}
			else
			{
				EnabeRenderers();
			}
		}

		private void EnabeRenderers()
		{
			Renderer[] array = disabledRenderers;
			foreach (Renderer renderer in array)
			{
				if ((bool)renderer)
				{
					renderer.enabled = true;
				}
			}
		}

		private void DisableRenderers()
		{
			disabledRenderers = GetComponentsInChildren<Renderer>();
			Renderer[] array = disabledRenderers;
			foreach (Renderer renderer in array)
			{
				renderer.enabled = false;
			}
		}
	}
}
