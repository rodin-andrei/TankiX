using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientPaymentGUI.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PremiumPackComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI _daysText;

		[SerializeField]
		private TextMeshProUGUI _daysDescriptionText;

		[SerializeField]
		private TextMeshProUGUI _priceText;

		[SerializeField]
		private GameObject _xCrystals;

		[SerializeField]
		private GameObject _saleContainer;

		[SerializeField]
		private TextMeshProUGUI _salePercentText;

		[SerializeField]
		private PremiumLearnMoreButtonComponent _learnMoreButton;

		[SerializeField]
		private PurchaseButtonComponent _premiumPurchaseButton;

		public string DaysText
		{
			set
			{
				_daysText.text = value;
			}
		}

		public string DaysDescription
		{
			set
			{
				_daysDescriptionText.text = value;
			}
		}

		public string Price
		{
			set
			{
				_priceText.text = value;
			}
		}

		public bool HasXCrystals
		{
			set
			{
				_xCrystals.SetActive(value);
			}
		}

		public float Discount
		{
			set
			{
				if (value > 0f)
				{
					_saleContainer.SetActive(true);
					_salePercentText.text = string.Format("-{0:0}%", value * 100f);
				}
				else
				{
					_saleContainer.SetActive(false);
				}
			}
		}

		public int LearnMoreIndex
		{
			set
			{
				_learnMoreButton.idx = value;
			}
		}

		public Entity GoodsEntity
		{
			set
			{
				_premiumPurchaseButton.GoodsEntity = value;
			}
		}
	}
}
