using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class VulcanBandAnimationComponent : ECSBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private int materialIndex = 1;

		[SerializeField]
		private float speed = 1f;

		[SerializeField]
		private float bandCooldownSec = 0.2f;

		[SerializeField]
		private float partCount = 36f;

		[SerializeField]
		private string[] textureNames = new string[6]
		{
			"_MainTex",
			"_PaintMap",
			"_FrostTex",
			"_HeatTex",
			"_SurfaceMap",
			"_BumpMap"
		};

		private Material bandMaterial;

		private float offset;

		private float stepLength;

		private Entity vulcanEntity;

		private float currentStepDistance;

		private float currentCooldown;

		private bool isEjectorEnabled;

		private void Awake()
		{
			base.enabled = false;
		}

		private void OnEnable()
		{
			currentStepDistance = 0f;
			currentCooldown = 0f;
			isEjectorEnabled = true;
		}

		private void ProvideCaseEjectionEvent(Engine engine)
		{
			NewEvent<CartridgeCaseEjectionEvent>().Attach(vulcanEntity).Schedule();
		}

		private void Update()
		{
			if (currentCooldown > 0f)
			{
				currentCooldown -= Time.deltaTime;
				return;
			}
			if (isEjectorEnabled)
			{
				isEjectorEnabled = false;
				ProvideCaseEjectionEvent(ECSBehaviour.EngineService.Engine);
			}
			float num = speed * Time.deltaTime;
			currentStepDistance += num;
			offset += num;
			offset = Mathf.Repeat(offset, 1f);
			int num2 = textureNames.Length;
			for (int i = 0; i < num2; i++)
			{
				bandMaterial.SetTextureOffset(textureNames[i], new Vector2(offset, 0f));
			}
			if (Mathf.Abs(currentStepDistance) >= stepLength)
			{
				currentStepDistance = 0f;
				currentCooldown = bandCooldownSec;
				isEjectorEnabled = true;
			}
		}

		public void InitBand(Renderer renderer, Entity entity)
		{
			vulcanEntity = entity;
			bandMaterial = renderer.materials[materialIndex];
			stepLength = 1f / partCount;
			offset = 0f;
		}

		public void StartBandAnimation()
		{
			base.enabled = true;
		}

		public void StopBandAnimation()
		{
			base.enabled = false;
		}
	}
}
