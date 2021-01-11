using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectOnStartSendCollision : MonoBehaviour
	{
		private UpdateRankEffectSettings effectSettings;

		private bool isInitialized;

		private void GetEffectSettingsComponent(Transform tr)
		{
			Transform parent = tr.parent;
			if (parent != null)
			{
				effectSettings = parent.GetComponentInChildren<UpdateRankEffectSettings>();
				if (effectSettings == null)
				{
					GetEffectSettingsComponent(parent.transform);
				}
			}
		}

		private void Start()
		{
			GetEffectSettingsComponent(base.transform);
			effectSettings.OnCollisionHandler(new UpdateRankCollisionInfo());
			isInitialized = true;
		}

		private void OnEnable()
		{
			if (isInitialized)
			{
				effectSettings.OnCollisionHandler(new UpdateRankCollisionInfo());
			}
		}
	}
}
