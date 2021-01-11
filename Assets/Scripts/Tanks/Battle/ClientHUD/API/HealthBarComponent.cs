using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientControls.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.API
{
	public class HealthBarComponent : ProgressBarComponent
	{
		private float actualValue;

		private float animatedValue;

		private bool animating;

		private float animationTime;

		private CanvasGroup _canvasGroup;

		private float _defaultAlpha;

		[Inject]
		public static UnityTime Time
		{
			get;
			set;
		}

		public override float ProgressValue
		{
			get
			{
				if (animating)
				{
					return actualValue;
				}
				return base.ProgressValue;
			}
			set
			{
				if (animating)
				{
					actualValue = value;
				}
				else
				{
					base.ProgressValue = value;
				}
			}
		}

		private void OnEnable()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			_defaultAlpha = _canvasGroup.alpha;
		}

		public void HideHealthBar()
		{
			_canvasGroup.alpha = 0f;
			base.gameObject.transform.SetAsFirstSibling();
		}

		public void ShowHealthBar()
		{
			_canvasGroup.alpha = _defaultAlpha;
			base.gameObject.transform.SetAsLastSibling();
		}

		public void ActivateAnimation(float timeInSec)
		{
			animationTime = timeInSec;
			animating = true;
			actualValue = base.ProgressValue;
			animatedValue = 0f;
		}

		protected override void Update()
		{
			base.Update();
			if (animating)
			{
				animatedValue += Time.deltaTime / animationTime;
				if (animatedValue >= 1f)
				{
					animating = false;
					base.ProgressValue = actualValue;
				}
				base.ProgressValue = animatedValue;
			}
		}
	}
}
