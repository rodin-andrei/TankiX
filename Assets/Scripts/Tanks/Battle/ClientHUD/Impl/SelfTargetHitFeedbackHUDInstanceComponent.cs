using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class SelfTargetHitFeedbackHUDInstanceComponent : BehaviourComponent
	{
		private const float HEIGHT_ROOT = 5f;

		[SerializeField]
		private EntityBehaviour entityBehaviour;

		[SerializeField]
		private Vector2 minSize = new Vector2(150f, 200f);

		[SerializeField]
		private Vector2 maxSize = new Vector2(300f, 400f);

		[SerializeField]
		private Vector2 relativeSizeCoeff = new Vector2(0.1f, 0.2f);

		[SerializeField]
		private float lengthPercent = 0.001f;

		[SerializeField]
		[Range(0f, 1f)]
		[HideInInspector]
		private float lengthInterpolator;

		[SerializeField]
		private RectTransform rootRectTransform;

		[SerializeField]
		private RectTransform imageRectTransform;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private Image image;

		[SerializeField]
		private int fps = 30;

		[SerializeField]
		private int frameCount = 6;

		[SerializeField]
		[HideInInspector]
		private float alpha;

		private int appearID;

		private int disappearID;

		private int colorID;

		private Entity entity;

		private Material material;

		private float requiredLength;

		private float length;

		private float slopeAddition;

		private float width;

		private float animationFrameTime;

		private float animationTimer;

		private float frameOffset;

		private int textureID;

		private int currentFrameIndex;

		private SelfTargetHitEffectHUDData initialData;

		public SelfTargetHitEffectHUDData InitialData
		{
			get
			{
				return initialData;
			}
		}

		public void Init(Entity entity, SelfTargetHitEffectHUDData data)
		{
			InitTransform(data);
			InitMaterial();
			UpdateTransform(data);
			UpdateSpriteFrame();
			this.entity = entity;
			entityBehaviour.BuildEntity(entity);
			base.gameObject.SetActive(true);
		}

		private void InitTransform(SelfTargetHitEffectHUDData data)
		{
			initialData = data;
			Vector2 cnvSize = data.CnvSize;
			float num = Mathf.Min(cnvSize.x, cnvSize.y);
			width = Mathf.Clamp(num * relativeSizeCoeff.x, minSize.x, maxSize.x);
			lengthInterpolator = 1f;
			requiredLength = Mathf.Clamp(num * relativeSizeCoeff.y, minSize.y, Mathf.Min(maxSize.y, Mathf.Max(data.Length * lengthPercent, minSize.y)));
			length = 0f;
		}

		private void InitMaterial()
		{
			animationTimer = 0f;
			animationFrameTime = 1f / (float)fps;
			alpha = 0f;
			colorID = Shader.PropertyToID("_Color");
			material = UnityEngine.Object.Instantiate(image.material);
			image.material = material;
			textureID = Shader.PropertyToID("_MainTex");
			frameOffset = 1f / (float)frameCount;
			material.SetTextureScale(textureID, new Vector2(frameOffset, 1f));
			currentFrameIndex = -1;
		}

		public void UpdateTransform(SelfTargetHitEffectHUDData data)
		{
			rootRectTransform.localPosition = data.BoundsPosCanvas;
			rootRectTransform.localRotation = Quaternion.LookRotation(Vector3.forward, data.UpwardsNrm);
			UpdateSlope(data);
			UpdateSize();
		}

		private void UpdateSlope(SelfTargetHitEffectHUDData data)
		{
			float num = width * 0.5f;
			float axisAngle = GetAxisAngle(data.UpwardsNrm, Vector2.right);
			float axisAngle2 = GetAxisAngle(data.UpwardsNrm, Vector2.up);
			float num2 = ((!(Mathf.Abs(Mathf.Abs(data.BoundsPosition.x - 0.5f) - 0.5f) <= 0.001f)) ? axisAngle : axisAngle2);
			float f = num / Mathf.Tan((float)Math.PI / 180f * num2);
			if (!float.IsInfinity(f) && !float.IsNaN(f))
			{
				slopeAddition = f;
			}
		}

		private void UpdateSpriteFrame()
		{
			int num = UnityEngine.Random.Range(0, frameCount);
			if (num == currentFrameIndex)
			{
				num++;
				if (num >= frameCount)
				{
					currentFrameIndex = 0;
				}
			}
			else
			{
				currentFrameIndex = num;
			}
			material.SetTextureOffset(textureID, new Vector2((float)currentFrameIndex * frameOffset, 0f));
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			if (animationTimer > 0f)
			{
				animationTimer -= deltaTime;
				return;
			}
			UpdateSpriteFrame();
			animationTimer = animationFrameTime;
		}

		private void UpdateSize()
		{
			length = Mathf.Lerp(0f, requiredLength, lengthInterpolator);
			Vector2 vector = new Vector2(width, 5f);
			rootRectTransform.sizeDelta = vector;
			float num = length + slopeAddition;
			Vector2 sizeDelta = vector;
			sizeDelta.y = num;
			float y = num * 0.5f - slopeAddition;
			imageRectTransform.sizeDelta = sizeDelta;
			imageRectTransform.localPosition = new Vector3(0f, y, 0f);
		}

		private void LateUpdate()
		{
			UpdateSize();
			Color value = new Color(1f, 1f, 1f, alpha);
			material.SetColor(colorID, value);
		}

		private float GetAxisAngle(Vector2 vec, Vector2 axis)
		{
			float num = Vector2.Angle(vec, axis);
			if (num > 90f)
			{
				num = 180f - num;
			}
			return num;
		}

		private void OnDisappeared()
		{
			ECSBehaviour.EngineService.Engine.DeleteEntity(entity);
		}
	}
}
