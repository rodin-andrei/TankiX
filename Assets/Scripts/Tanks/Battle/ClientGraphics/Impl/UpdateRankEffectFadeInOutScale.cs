using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectFadeInOutScale : MonoBehaviour
	{
		public UpdateRankEffectFadeInOutStatus FadeInOutStatus;

		public float Speed = 1f;

		public float MaxScale = 2f;

		private Vector3 oldScale;

		private float time;

		private float oldSin;

		private bool updateTime = true;

		private bool canUpdate = true;

		private Transform t;

		private UpdateRankEffectSettings effectSettings;

		private bool isInitialized;

		private bool isCollisionEnter;

		private void Start()
		{
			t = base.transform;
			oldScale = t.localScale;
			isInitialized = true;
			GetEffectSettingsComponent(base.transform);
			if (effectSettings != null)
			{
				effectSettings.CollisionEnter += prefabSettings_CollisionEnter;
			}
		}

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

		public void InitDefaultVariables()
		{
			if (FadeInOutStatus == UpdateRankEffectFadeInOutStatus.OutAfterCollision)
			{
				t.localScale = oldScale;
				canUpdate = false;
			}
			else
			{
				t.localScale = Vector3.zero;
				canUpdate = true;
			}
			updateTime = true;
			time = 0f;
			oldSin = 0f;
			isCollisionEnter = false;
		}

		private void prefabSettings_CollisionEnter(object sender, UpdateRankCollisionInfo e)
		{
			isCollisionEnter = true;
			canUpdate = true;
		}

		private void OnEnable()
		{
			if (isInitialized)
			{
				InitDefaultVariables();
			}
		}

		private void Update()
		{
			if (!canUpdate)
			{
				return;
			}
			if (updateTime)
			{
				time = Time.time;
				updateTime = false;
			}
			float num = Mathf.Sin((Time.time - time) / Speed);
			float num2;
			if (oldSin > num)
			{
				canUpdate = false;
				num2 = MaxScale;
			}
			else
			{
				num2 = num * MaxScale;
			}
			if (FadeInOutStatus == UpdateRankEffectFadeInOutStatus.In)
			{
				if (num2 < MaxScale)
				{
					t.localScale = new Vector3(oldScale.x * num2, oldScale.y * num2, oldScale.z * num2);
				}
				else
				{
					t.localScale = new Vector3(MaxScale, MaxScale, MaxScale);
				}
			}
			if (FadeInOutStatus == UpdateRankEffectFadeInOutStatus.Out)
			{
				if (num2 > 0f)
				{
					t.localScale = new Vector3(MaxScale * oldScale.x - oldScale.x * num2, MaxScale * oldScale.y - oldScale.y * num2, MaxScale * oldScale.z - oldScale.z * num2);
				}
				else
				{
					t.localScale = Vector3.zero;
				}
			}
			if (FadeInOutStatus == UpdateRankEffectFadeInOutStatus.OutAfterCollision && isCollisionEnter)
			{
				if (num2 > 0f)
				{
					t.localScale = new Vector3(MaxScale * oldScale.x - oldScale.x * num2, MaxScale * oldScale.y - oldScale.y * num2, MaxScale * oldScale.z - oldScale.z * num2);
				}
				else
				{
					t.localScale = Vector3.zero;
				}
			}
			oldSin = num;
		}
	}
}
