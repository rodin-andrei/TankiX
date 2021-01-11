using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class StreamEffectBehaviour : MonoBehaviour
	{
		private const float STRAIGHT_DIR = 1f;

		private const float REVERSE_DIR = -1f;

		[SerializeField]
		private float range;

		[SerializeField]
		private AnimationCurve nearIntensityEasing;

		[SerializeField]
		private AnimationCurve farIntensityEasing;

		[SerializeField]
		private Light nearLight;

		[SerializeField]
		private Light farLight;

		[SerializeField]
		private float farLightDefaultSpeed = 1f;

		[SerializeField]
		private float farLightMaxSpeed = 4f;

		private Animator nearAnimator;

		private Animator farAnimator;

		private ParticleSystem particleSystem;

		private float nearIntensityTime;

		private float farIntensityTime;

		private float easingDirection;

		private Vector3 farLightStartPosition;

		private bool lightIsEnabled = true;

		public float Range
		{
			get
			{
				return range;
			}
			set
			{
				range = value;
			}
		}

		public void Awake()
		{
			particleSystem = GetComponent<ParticleSystem>();
			nearAnimator = nearLight.GetComponent<Animator>();
			farAnimator = farLight.GetComponent<Animator>();
			farLightStartPosition = farLight.transform.localPosition;
			Stop();
		}

		private void Update()
		{
			float num = range + farLightStartPosition.z;
			Vector3 end = base.transform.position + base.transform.forward * num;
			float num2 = farLightDefaultSpeed;
			RaycastHit hitInfo;
			if (Physics.Linecast(base.transform.position - base.transform.forward, end, out hitInfo, LayerMasks.VISUAL_STATIC))
			{
				num2 = farLightMaxSpeed;
				num = Vector3.Distance(base.transform.position, hitInfo.point);
			}
			Vector3 localPosition = farLight.transform.localPosition;
			localPosition.z = Mathf.Lerp(localPosition.z, num, Time.deltaTime * num2);
			farLight.transform.localPosition = localPosition;
		}

		private void LateUpdate()
		{
			float deltaTime = Time.deltaTime;
			float num = float.Epsilon;
			nearIntensityTime = Mathf.Clamp(nearIntensityTime + easingDirection * deltaTime, 0f, nearIntensityEasing.keys[nearIntensityEasing.keys.Length - 1].time);
			farIntensityTime = Mathf.Clamp(farIntensityTime + easingDirection * deltaTime, 0f, farIntensityEasing.keys[farIntensityEasing.keys.Length - 1].time);
			float num2 = nearIntensityEasing.Evaluate(nearIntensityTime);
			float num3 = farIntensityEasing.Evaluate(farIntensityTime);
			nearLight.enabled = num2 > num;
			farLight.enabled = num3 > num;
			nearLight.intensity *= num2;
			farLight.intensity *= num3;
			nearAnimator.enabled = nearLight.enabled;
			farAnimator.enabled = farLight.enabled;
			base.enabled = nearLight.enabled || farLight.enabled;
		}

		public void Play()
		{
			farLight.transform.localPosition = farLightStartPosition;
			particleSystem.Play(true);
			easingDirection = 1f;
			base.enabled = lightIsEnabled;
		}

		public void Stop()
		{
			base.enabled = lightIsEnabled;
			easingDirection = -1f;
			if ((bool)particleSystem)
			{
				particleSystem.Stop(true);
			}
		}

		public virtual void ApplySettings(StreamWeaponSettingsComponent streamWeaponSettings)
		{
			if (!streamWeaponSettings.LightIsEnabled)
			{
				lightIsEnabled = false;
				farLight.enabled = false;
				nearLight.enabled = false;
				base.enabled = false;
			}
		}

		public virtual void AddCollisionLayer(int layer)
		{
		}
	}
}
