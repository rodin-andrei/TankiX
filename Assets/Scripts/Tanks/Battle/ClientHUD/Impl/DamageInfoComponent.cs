using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class DamageInfoComponent : BehaviourComponent
	{
		public Material criticalMaterialPreset;

		public TextMeshProUGUI text;

		private Camera _cachedCamera;

		public Camera CachedCamera
		{
			get
			{
				if (!_cachedCamera)
				{
					_cachedCamera = Camera.main;
				}
				return _cachedCamera;
			}
		}
	}
}
