using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectInvokeInterval : MonoBehaviour
	{
		public GameObject GO;

		public float Interval = 0.3f;

		public float Duration = 3f;

		private List<GameObject> goInstances;

		private UpdateRankEffectSettings effectSettings;

		private int goIndexActivate;

		private int goIndexDeactivate;

		private bool isInitialized;

		private int count;

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
			goInstances = new List<GameObject>();
			count = (int)(Duration / Interval);
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(GO, base.transform.position, default(Quaternion));
				gameObject.transform.parent = base.transform;
				UpdateRankEffectSettings component = gameObject.GetComponent<UpdateRankEffectSettings>();
				component.Target = effectSettings.Target;
				component.IsHomingMove = effectSettings.IsHomingMove;
				component.MoveDistance = effectSettings.MoveDistance;
				component.MoveSpeed = effectSettings.MoveSpeed;
				component.CollisionEnter += delegate(object n, UpdateRankCollisionInfo e)
				{
					effectSettings.OnCollisionHandler(e);
				};
				component.ColliderRadius = effectSettings.ColliderRadius;
				component.EffectRadius = effectSettings.EffectRadius;
				component.EffectDeactivated += effectSettings_EffectDeactivated;
				goInstances.Add(gameObject);
				gameObject.SetActive(false);
			}
			InvokeAll();
			isInitialized = true;
		}

		private void InvokeAll()
		{
			for (int i = 0; i < count; i++)
			{
				Invoke("InvokeInstance", (float)i * Interval);
			}
		}

		private void InvokeInstance()
		{
			goInstances[goIndexActivate].SetActive(true);
			if (goIndexActivate >= goInstances.Count - 1)
			{
				goIndexActivate = 0;
			}
			else
			{
				goIndexActivate++;
			}
		}

		private void effectSettings_EffectDeactivated(object sender, EventArgs e)
		{
			UpdateRankEffectSettings updateRankEffectSettings = sender as UpdateRankEffectSettings;
			updateRankEffectSettings.transform.position = base.transform.position;
			if (goIndexDeactivate >= count - 1)
			{
				effectSettings.Deactivate();
				goIndexDeactivate = 0;
			}
			else
			{
				goIndexDeactivate++;
			}
		}

		private void OnEnable()
		{
			if (isInitialized)
			{
				InvokeAll();
			}
		}

		private void OnDisable()
		{
		}
	}
}
