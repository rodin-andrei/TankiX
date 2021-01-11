using System;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class IsisRayEffectBehaviour : MonoBehaviour
	{
		private const float TAU = (float)Math.PI * 2f;

		[Header("Assets")]
		[SerializeField]
		private ParticleSystem expandingBlob;

		[SerializeField]
		private ParticleSystem contractingBlob;

		[SerializeField]
		private LineRenderer[] rays;

		[SerializeField]
		private Material damagingBallMaterial;

		[SerializeField]
		private Material damagingRayMaterial;

		[SerializeField]
		private Material healingBallMaterial;

		[SerializeField]
		private Material healingRayMaterial;

		[Space(1f)]
		[Header("Initialization parameters")]
		[SerializeField]
		private int curvesCount = 5;

		[SerializeField]
		private float minCurveMagnitude = 0.05f;

		[SerializeField]
		private float maxCurveMagnitude = 0.1f;

		[Space(1f)]
		[Header("Dynamic parameters")]
		[SerializeField]
		private float offsetToCamera = 0.5f;

		[SerializeField]
		private float smoothingSpeed = 1f;

		[SerializeField]
		private float[] textureTilings;

		[SerializeField]
		private float[] textureOffsets;

		[SerializeField]
		private float verticesSpacing = 0.5f;

		[SerializeField]
		private float curveLength = 5f;

		[SerializeField]
		private float curveSpeed = 0.5f;

		[SerializeField]
		private Color healColor;

		[SerializeField]
		private Color damageColor;

		private float textureScrollDirection = 1f;

		private Vector3[] bezierPoints = new Vector3[3];

		private AnimationCurve curve;

		private ParticleSystemRenderer expandingBlobRenderer;

		private ParticleSystemRenderer contractingBlobRenderer;

		private Light expandingLight;

		private Light contractingLight;

		private Animation expandingAnimation;

		private Animation contractingAnimation;

		private ParticleSystem nearBlob;

		private ParticleSystem farBlob;

		private Light nearLight;

		private Light farLight;

		private Animation nearAnimation;

		private Animation farAnimation;

		private ParticleSystemRenderer nearBlobRenderer;

		private ParticleSystemRenderer farBlobRenderer;

		[SerializeField]
		private Material[] damagingRayMaterials;

		[SerializeField]
		private Material[] healingRayMaterials;

		private Vector3 endLocalPosition;

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

		private void Update()
		{
			for (int i = 0; i < rays.Length; i++)
			{
				Vector2 mainTextureOffset = rays[i].sharedMaterial.mainTextureOffset;
				mainTextureOffset.x = (mainTextureOffset.x + textureOffsets[i] * textureScrollDirection * Time.deltaTime) % 1f;
				rays[i].sharedMaterial.mainTextureOffset = mainTextureOffset;
			}
		}

		public void Init()
		{
			damagingRayMaterials = new Material[rays.Length];
			healingRayMaterials = new Material[rays.Length];
			for (int i = 0; i < rays.Length; i++)
			{
				damagingRayMaterials[i] = UnityEngine.Object.Instantiate(damagingRayMaterial);
				healingRayMaterials[i] = UnityEngine.Object.Instantiate(healingRayMaterial);
			}
			expandingBlobRenderer = expandingBlob.GetComponent<ParticleSystemRenderer>();
			contractingBlobRenderer = contractingBlob.GetComponent<ParticleSystemRenderer>();
			expandingLight = expandingBlob.GetComponent<Light>();
			contractingLight = contractingBlob.GetComponent<Light>();
			expandingAnimation = expandingBlob.GetComponent<Animation>();
			contractingAnimation = contractingBlob.GetComponent<Animation>();
			InitCurve();
			Hide();
		}

		public void Show()
		{
			EnableBlob(nearBlob, nearLight, nearAnimation);
		}

		public void Hide()
		{
			for (int i = 0; i < rays.Length; i++)
			{
				LineRenderer lineRenderer = rays[i];
				if ((bool)lineRenderer)
				{
					rays[i].enabled = false;
				}
			}
			SetHealingMode();
			DisableBlob(nearBlob, nearLight, nearAnimation);
			DisableBlob(farBlob, farLight, farAnimation);
			base.enabled = false;
		}

		public void EnableTargetForHealing()
		{
			base.enabled = true;
			EnableBlob(farBlob, farLight, farAnimation);
			SetHealingMode();
			for (int i = 0; i < rays.Length; i++)
			{
				rays[i].enabled = true;
			}
		}

		public void EnableTargetForDamaging()
		{
			base.enabled = true;
			EnableBlob(farBlob, farLight, farAnimation);
			SetDamagingMode();
			for (int i = 0; i < rays.Length; i++)
			{
				rays[i].enabled = true;
			}
		}

		public void DisableTarget()
		{
			LineRenderer[] array = rays;
			foreach (LineRenderer lineRenderer in array)
			{
				if ((bool)lineRenderer)
				{
					lineRenderer.enabled = false;
				}
			}
			SetHealingMode();
			DisableBlob(farBlob, farLight, farAnimation);
			base.enabled = false;
		}

		public void UpdateTargetPosition(Transform targetTransform, Vector3 targetLocalPosition, float[] speedMultipliers, float[] pointsRandomness)
		{
			bezierPoints[0] = base.transform.position;
			float speed = speedMultipliers[1] * smoothingSpeed;
			float speed2 = speedMultipliers[2] * smoothingSpeed;
			Vector3 from = targetTransform.InverseTransformPoint(base.transform.position);
			endLocalPosition = MovePoint(endLocalPosition, from, targetLocalPosition, speed2, pointsRandomness[2]);
			bezierPoints[2] = targetTransform.TransformPoint(endLocalPosition);
			Vector3 to = Vector3.Lerp(base.transform.position, bezierPoints[2], 0.5f);
			bezierPoints[1] = MovePoint(bezierPoints[1], base.transform.position, to, speed, pointsRandomness[1]);
			nearBlob.transform.position = bezierPoints[0];
			farBlob.transform.position = bezierPoints[2] + (CachedCamera.transform.position - bezierPoints[2]).normalized * offsetToCamera;
			Vector3 lhs = bezierPoints[2] - bezierPoints[0];
			float magnitude = lhs.magnitude;
			Vector3 normalized = Vector3.Cross(lhs, CachedCamera.transform.forward).normalized;
			float num = magnitude / (curveLength * (float)curvesCount);
			int num2 = 1 + Mathf.CeilToInt(magnitude / verticesSpacing);
			for (int i = 0; i < rays.Length; i++)
			{
				rays[i].SetVertexCount(num2);
				for (int j = 0; j < num2; j++)
				{
					float num3 = (float)j / (float)(num2 - 1);
					Vector3 vector = Bezier.PointOnCurve(num3, bezierPoints[0], bezierPoints[1], bezierPoints[2]);
					float time = (num3 * num + textureScrollDirection * curveSpeed * Time.time) % 1f;
					Vector3 vector2 = normalized * curve.Evaluate(time);
					rays[i].SetPosition(j, vector + vector2);
				}
				Vector2 mainTextureScale = rays[i].sharedMaterial.mainTextureScale;
				mainTextureScale.x = magnitude / textureTilings[i];
				rays[i].sharedMaterial.mainTextureScale = mainTextureScale;
			}
		}

		private Vector3 MovePoint(Vector3 moveThis, Vector3 from, Vector3 to, float speed, float randomness)
		{
			Vector3 vector = Quaternion.LookRotation(to - from) * UnityEngine.Random.insideUnitCircle * randomness;
			return Vector3.MoveTowards(moveThis, to + vector, Time.deltaTime * speed);
		}

		private void SetHealingMode()
		{
			textureScrollDirection = -1f;
			SetBlobs(expandingBlob, expandingBlobRenderer, expandingLight, expandingAnimation, contractingBlob, contractingBlobRenderer, contractingLight, contractingAnimation);
			nearBlobRenderer.sharedMaterial = healingBallMaterial;
			farBlobRenderer.sharedMaterial = healingBallMaterial;
			nearLight.color = healColor;
			farLight.color = healColor;
			for (int i = 0; i < rays.Length; i++)
			{
				rays[i].material = healingRayMaterials[i];
			}
		}

		private void SetDamagingMode()
		{
			textureScrollDirection = 1f;
			SetBlobs(contractingBlob, contractingBlobRenderer, contractingLight, contractingAnimation, expandingBlob, expandingBlobRenderer, expandingLight, expandingAnimation);
			nearBlobRenderer.sharedMaterial = damagingBallMaterial;
			farBlobRenderer.sharedMaterial = damagingBallMaterial;
			nearLight.color = damageColor;
			farLight.color = damageColor;
			for (int i = 0; i < rays.Length; i++)
			{
				rays[i].material = damagingRayMaterials[i];
			}
		}

		private void SetBlobs(ParticleSystem nearBlob, ParticleSystemRenderer nearBlobRenderer, Light nearLight, Animation nearAnimation, ParticleSystem farBlob, ParticleSystemRenderer farBlobRenderer, Light farLight, Animation farAnimation)
		{
			this.nearBlob = nearBlob;
			this.nearBlobRenderer = nearBlobRenderer;
			this.nearBlob.transform.localPosition = Vector3.zero;
			this.nearLight = nearLight;
			this.nearAnimation = nearAnimation;
			this.farBlob = farBlob;
			this.farBlobRenderer = farBlobRenderer;
			this.farBlob.transform.localPosition = Vector3.zero;
			this.farLight = farLight;
			this.farAnimation = farAnimation;
		}

		private void InitCurve()
		{
			float value = UnityEngine.Random.value;
			Keyframe[] array = new Keyframe[5 * curvesCount];
			for (int i = 0; i < array.Length; i++)
			{
				array[i].time = (float)i / (float)(array.Length - 1);
				array[i].value = Mathf.Sin((array[i].time * (float)curvesCount + value) * ((float)Math.PI * 2f)) * UnityEngine.Random.Range(minCurveMagnitude, maxCurveMagnitude);
			}
			curve = new AnimationCurve(array);
		}

		private static void EnableBlob(ParticleSystem blob, Light light, Animation animation)
		{
			blob.enableEmission = true;
			blob.Emit(1);
			blob.Play();
			light.enabled = true;
			animation.enabled = true;
		}

		private static void DisableBlob(ParticleSystem blob, Light light, Animation animation)
		{
			blob.Stop();
			blob.Clear();
			blob.enableEmission = false;
			light.enabled = false;
			animation.enabled = false;
		}
	}
}
