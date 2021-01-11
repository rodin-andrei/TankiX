using System.Collections;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class MultikillUIComponent : BehaviourComponent
	{
		private static string ACTIVATE_TRIGGER = "Activate";

		private static string DEACTIVATE_TRIGGER = "Deactivate";

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private AssetReference voiceReference;

		[SerializeField]
		private LocalizedField multikillText;

		[SerializeField]
		private LocalizedField streakText;

		[SerializeField]
		private TextMeshProUGUI multikillTextField;

		[SerializeField]
		private TextMeshProUGUI streakTextField;

		[SerializeField]
		private AnimatedLong scoreText;

		[SerializeField]
		private bool disableVoice;

		private Coroutine coroutine;

		private GameObject voiceInstance;

		public Animator Animator
		{
			get
			{
				return animator;
			}
		}

		public AssetReference VoiceReference
		{
			get
			{
				return voiceReference;
			}
		}

		public GameObject Voice
		{
			get;
			set;
		}

		public void ActivateEffect(int score = 0, int kills = 0, string userName = "")
		{
			if (multikillText != null && !string.IsNullOrEmpty(multikillText.Value))
			{
				multikillTextField.text = multikillText.Value;
			}
			scoreText.Value = score;
			if (kills > 0)
			{
				streakTextField.text = string.Format(streakText.Value, kills);
			}
			else if (!string.IsNullOrEmpty(userName))
			{
				streakTextField.text = string.Format(streakText.Value, userName);
				streakTextField.gameObject.SetActive(true);
			}
			else
			{
				streakTextField.gameObject.SetActive(false);
			}
			CancelCoroutine();
			coroutine = StartCoroutine(SetTrigger(ACTIVATE_TRIGGER));
		}

		public void DeactivateEffect()
		{
			CancelCoroutine();
			animator.SetTrigger(DEACTIVATE_TRIGGER);
		}

		private void CancelCoroutine()
		{
			if (coroutine != null)
			{
				StopCoroutine(coroutine);
				coroutine = null;
			}
		}

		private IEnumerator SetTrigger(string state)
		{
			yield return new WaitForEndOfFrame();
			animator.SetTrigger(state);
		}

		public void PlayVoice()
		{
			if (!(Voice == null) && !disableVoice)
			{
				voiceInstance = Object.Instantiate(Voice);
			}
		}

		public void StopVoice()
		{
			if (!(Voice == null))
			{
				Object.Destroy(voiceInstance);
			}
		}
	}
}
