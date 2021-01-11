using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectFadeInOutShaderFloat : MonoBehaviour
	{
		public string PropertyName = "_CutOut";

		public float MaxFloat = 1f;

		public float StartDelay;

		public float FadeInSpeed;

		public float FadeOutDelay;

		public float FadeOutSpeed;

		public bool FadeOutAfterCollision;

		public bool UseHideStatus;

		private Material OwnMaterial;

		private Material mat;

		private float oldFloat;

		private float currentFloat;

		private bool canStart;

		private bool canStartFadeOut;

		private bool fadeInComplited;

		private bool fadeOutComplited;

		private bool previousFrameVisibleStatus;

		private bool isCollisionEnter;

		private bool isStartDelay;

		private bool isIn;

		private bool isOut;

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
			if (effectSettings != null)
			{
				effectSettings.CollisionEnter += prefabSettings_CollisionEnter;
			}
			InitMaterial();
		}

		public void UpdateMaterial(Material instanceMaterial)
		{
			mat = instanceMaterial;
			InitMaterial();
		}

		private void InitMaterial()
		{
			if (isInitialized)
			{
				return;
			}
			if (GetComponent<Renderer>() != null)
			{
				mat = GetComponent<Renderer>().material;
			}
			else
			{
				LineRenderer component = GetComponent<LineRenderer>();
				if (component != null)
				{
					mat = component.material;
				}
				else
				{
					Projector component2 = GetComponent<Projector>();
					if (component2 != null)
					{
						if (!component2.material.name.EndsWith("(Instance)"))
						{
							component2.material = new Material(component2.material)
							{
								name = component2.material.name + " (Instance)"
							};
						}
						mat = component2.material;
					}
				}
			}
			if (!(mat == null))
			{
				isStartDelay = StartDelay > 0.001f;
				isIn = FadeInSpeed > 0.001f;
				isOut = FadeOutSpeed > 0.001f;
				InitDefaultVariables();
				isInitialized = true;
			}
		}

		private void InitDefaultVariables()
		{
			fadeInComplited = false;
			fadeOutComplited = false;
			canStartFadeOut = false;
			canStart = false;
			isCollisionEnter = false;
			oldFloat = 0f;
			currentFloat = MaxFloat;
			if (isIn)
			{
				currentFloat = 0f;
			}
			mat.SetFloat(PropertyName, currentFloat);
			if (isStartDelay)
			{
				Invoke("SetupStartDelay", StartDelay);
			}
			else
			{
				canStart = true;
			}
			if (!isIn)
			{
				if (!FadeOutAfterCollision)
				{
					Invoke("SetupFadeOutDelay", FadeOutDelay);
				}
				oldFloat = MaxFloat;
			}
		}

		private void prefabSettings_CollisionEnter(object sender, UpdateRankCollisionInfo e)
		{
			isCollisionEnter = true;
			if (!isIn && FadeOutAfterCollision)
			{
				Invoke("SetupFadeOutDelay", FadeOutDelay);
			}
		}

		private void OnEnable()
		{
			if (isInitialized)
			{
				InitDefaultVariables();
			}
		}

		private void SetupStartDelay()
		{
			canStart = true;
		}

		private void SetupFadeOutDelay()
		{
			canStartFadeOut = true;
		}

		private void Update()
		{
			if (!canStart)
			{
				return;
			}
			if (effectSettings != null && UseHideStatus)
			{
				if (!effectSettings.IsVisible && fadeInComplited)
				{
					fadeInComplited = false;
				}
				if (effectSettings.IsVisible && fadeOutComplited)
				{
					fadeOutComplited = false;
				}
			}
			if (UseHideStatus)
			{
				if (isIn && effectSettings != null && effectSettings.IsVisible && !fadeInComplited)
				{
					FadeIn();
				}
				if (isOut && effectSettings != null && !effectSettings.IsVisible && !fadeOutComplited)
				{
					FadeOut();
				}
			}
			else if (!FadeOutAfterCollision)
			{
				if (isIn && !fadeInComplited)
				{
					FadeIn();
				}
				if (isOut && canStartFadeOut && !fadeOutComplited)
				{
					FadeOut();
				}
			}
			else
			{
				if (isIn && !fadeInComplited)
				{
					FadeIn();
				}
				if (isOut && isCollisionEnter && canStartFadeOut && !fadeOutComplited)
				{
					FadeOut();
				}
			}
		}

		private void FadeIn()
		{
			currentFloat = oldFloat + Time.deltaTime / FadeInSpeed * MaxFloat;
			if (currentFloat >= MaxFloat)
			{
				fadeInComplited = true;
				currentFloat = MaxFloat;
				Invoke("SetupFadeOutDelay", FadeOutDelay);
			}
			mat.SetFloat(PropertyName, currentFloat);
			oldFloat = currentFloat;
		}

		private void FadeOut()
		{
			currentFloat = oldFloat - Time.deltaTime / FadeOutSpeed * MaxFloat;
			if (currentFloat <= 0f)
			{
				currentFloat = 0f;
				fadeOutComplited = true;
			}
			mat.SetFloat(PropertyName, currentFloat);
			oldFloat = currentFloat;
		}
	}
}
