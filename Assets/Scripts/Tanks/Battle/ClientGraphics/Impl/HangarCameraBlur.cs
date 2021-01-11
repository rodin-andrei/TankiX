using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HangarCameraBlur : MonoBehaviour
	{
		private void OnEnable()
		{
			HangarCameraPostProcessingActivator.ActivePanel = base.gameObject;
		}
	}
}
