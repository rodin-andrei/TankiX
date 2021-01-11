using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class QuestProgressGUIComponent : BehaviourComponent
	{
		[SerializeField]
		private AnimatedProgress progress;

		[SerializeField]
		private TextMeshProUGUI currentProgressValue;

		[SerializeField]
		private TextMeshProUGUI targetProgressValue;

		[SerializeField]
		private TextMeshProUGUI deltaProgressValue;

		[SerializeField]
		private Animator deltaProgressAnimator;

		public string TargetProgressValue
		{
			get
			{
				return targetProgressValue.text;
			}
			set
			{
				targetProgressValue.text = value;
			}
		}

		public string CurrentProgressValue
		{
			get
			{
				return currentProgressValue.text;
			}
			set
			{
				currentProgressValue.text = value;
			}
		}

		public string DeltaProgressValue
		{
			get
			{
				return deltaProgressValue.text;
			}
			set
			{
				deltaProgressValue.text = value;
				deltaProgressAnimator.SetTrigger("ShowProgressDelta");
			}
		}

		public void Initialize(float currentValue, float targetValue)
		{
			progress.InitialNormalizedValue = currentValue / targetValue;
			CurrentProgressValue = currentValue.ToString();
		}

		public void Set(float currentValue, float targetValue)
		{
			progress.NormalizedValue = currentValue / targetValue;
			CurrentProgressValue = currentValue.ToString();
		}

		private void DisableOutsideClickingOption()
		{
		}

		private void EnableOutsideClickingOption()
		{
		}
	}
}
