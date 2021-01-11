using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	[RequireComponent(typeof(Animator))]
	public class EffectHUDComponent : BehaviourComponent, AttachToEntityListener, DetachFromEntityListener
	{
		[SerializeField]
		private ImageSkin icon;

		[SerializeField]
		private Image indicator;

		[SerializeField]
		private Image indicatorLighting;

		[SerializeField]
		private Image durationProgress;

		[SerializeField]
		private PaletteColorField buffColor;

		[SerializeField]
		private PaletteColorField debuffColor;

		[SerializeField]
		private TextMeshProUGUI timerText;

		private bool ticking;

		private float duration;

		private float timer;

		private float lastTimer = -1f;

		private Entity entity;

		public void InitBuff(string icon)
		{
			Init(buffColor, icon);
		}

		public void InitDebuff(string icon)
		{
			Init(debuffColor, icon);
		}

		public void InitDuration(float duration)
		{
			SetFillAmount(durationProgress, 1f);
			this.duration = duration;
			timer = 0f;
			ticking = duration != 0f;
			SetTimerText();
		}

		private void Init(PaletteColorField color, string icon)
		{
			Color color2 = color.Color;
			color2.a = 1f;
			indicator.color = color2;
			indicatorLighting.color = color2;
			this.icon.SpriteUid = icon;
		}

		private void Update()
		{
			if (!ticking)
			{
				return;
			}
			timer += Time.deltaTime;
			timer = Mathf.Min(timer, duration);
			if (timer != lastTimer)
			{
				lastTimer = timer;
				float num = 1f - timer / duration;
				SetFillAmount(durationProgress, num);
				if (num <= 0f)
				{
					ticking = false;
				}
				SetTimerText();
			}
		}

		private void SetFillAmount(Image image, float fillAmount)
		{
			image.rectTransform.anchorMax = new Vector2(1f, fillAmount);
		}

		private void SetTimerText()
		{
			timerText.text = string.Format("{0:0}", duration - timer);
		}

		public void Kill()
		{
			GetComponent<Animator>().SetTrigger("Kill");
		}

		private void OnReadyToDie()
		{
			base.gameObject.SetActive(false);
		}

		private void OnDisable()
		{
			if (ECSBehaviour.EngineService != null)
			{
				if (entity != null && entity.HasComponent<EffectHUDComponent>())
				{
					entity.RemoveComponent<EffectHUDComponent>();
				}
				Object.Destroy(base.gameObject);
			}
		}

		public void AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}

		public void DetachedFromEntity(Entity entity)
		{
			this.entity = null;
		}

		public void SetAllDirty()
		{
			Graphic[] componentsInChildren = GetComponentsInChildren<Graphic>(true);
			foreach (Graphic graphic in componentsInChildren)
			{
				graphic.SetAllDirty();
			}
		}
	}
}
