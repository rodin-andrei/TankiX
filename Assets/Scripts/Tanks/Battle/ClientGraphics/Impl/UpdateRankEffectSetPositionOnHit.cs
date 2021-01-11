using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectSetPositionOnHit : MonoBehaviour
	{
		public float OffsetPosition;

		private UpdateRankEffectSettings effectSettings;

		private Transform tRoot;

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
			if (effectSettings == null)
			{
				Debug.Log("Prefab root or children have not script \"PrefabSettings\"");
			}
			tRoot = effectSettings.transform;
		}

		private void effectSettings_CollisionEnter(object sender, UpdateRankCollisionInfo e)
		{
			Vector3 normalized = (tRoot.position + Vector3.Normalize(e.Hit.point - tRoot.position) * (effectSettings.MoveDistance + 1f)).normalized;
			base.transform.position = e.Hit.point - normalized * OffsetPosition;
		}

		private void Update()
		{
			if (!isInitialized)
			{
				isInitialized = true;
				effectSettings.CollisionEnter += effectSettings_CollisionEnter;
			}
		}

		private void OnDisable()
		{
			base.transform.position = Vector3.zero;
		}
	}
}
