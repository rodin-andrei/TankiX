using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientPayment.API;
using Tanks.Lobby.ClientProfile.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class SynthUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TMP_InputField crystals;

		[SerializeField]
		private TMP_InputField xCrystals;

		[SerializeField]
		private long defaultXCrystalsAmount = 100L;

		[SerializeField]
		private Animator synthButtonAnimator;

		[SerializeField]
		private ExchangeConfirmationWindow exchangeConfirmation;

		private bool calculating;

		private void Awake()
		{
			crystals.onValueChanged.AddListener(CalculateXCrystals);
			crystals.onEndEdit.AddListener(RoundCrystals);
			xCrystals.onValueChanged.AddListener(CalculateCrystals);
		}

		private void Start()
		{
			ValidateButton(long.Parse(crystals.text), long.Parse(xCrystals.text));
		}

		private void RoundCrystals(string value)
		{
			CalculateCrystals(xCrystals.text);
		}

		private void OnEnable()
		{
			if (string.IsNullOrEmpty(xCrystals.text))
			{
				xCrystals.text = defaultXCrystalsAmount.ToString();
				CalculateCrystals(xCrystals.text);
			}
		}

		public void SetCrystals(long cry)
		{
			crystals.text = cry.ToString();
			CalculateXCrystals(crystals.text);
		}

		public void SetXCrystals(long xcry)
		{
			xCrystals.text = xcry.ToString();
			CalculateCrystals(xCrystals.text);
		}

		private void CalculateXCrystals(string value)
		{
			if (!calculating)
			{
				calculating = true;
				long result = 0L;
				long.TryParse(value, out result);
				long num = (long)((float)result / ExchangeRateComponent.ExhchageRate);
				ValidateButton(result, num);
				xCrystals.text = num.ToString();
				calculating = false;
			}
		}

		private void CalculateCrystals(string value)
		{
			if (!calculating)
			{
				calculating = true;
				long result = 0L;
				long.TryParse(value, out result);
				long num = (long)((float)result * ExchangeRateComponent.ExhchageRate);
				ValidateButton(num, result);
				crystals.text = num.ToString();
				calculating = false;
			}
		}

		private void ValidateButton(long crystals, long xCrystals)
		{
			if (base.gameObject.activeInHierarchy)
			{
				synthButtonAnimator.SetBool("Visible", crystals > 0 && xCrystals > 0 && xCrystals <= SelfUserComponent.SelfUser.GetComponent<UserXCrystalsComponent>().Money);
			}
		}

		private void OnDisable()
		{
			crystals.text = string.Empty;
			xCrystals.text = string.Empty;
		}

		public void OnSynth()
		{
			long num = long.Parse(xCrystals.text);
			exchangeConfirmation.Show(SelfUserComponent.SelfUser, num, (long)(ExchangeRateComponent.ExhchageRate * (float)num));
		}

		public void OnXCrystalsChanged()
		{
			CalculateCrystals(xCrystals.text);
		}
	}
}
