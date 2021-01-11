using System;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class BuyEnergyDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private TextMeshProUGUI message;

		[SerializeField]
		private TextMeshProUGUI buyButtonText;

		[SerializeField]
		private LocalizedField messageLoc;

		[SerializeField]
		private LocalizedField buyButtonLoc;

		[SerializeField]
		private LocalizedField chargesAmountSingularText;

		[SerializeField]
		private LocalizedField chargesAmountPlural1Text;

		[SerializeField]
		private LocalizedField chargesAmountPlural2Text;

		private long energyCount;

		private long xprice;

		public long EnergyCount
		{
			get
			{
				return energyCount;
			}
		}

		public long Price
		{
			get
			{
				return xprice;
			}
		}

		public void Show(long count, long price)
		{
			energyCount = count;
			message.text = string.Format(messageLoc, Pluralize((int)energyCount));
			xprice = price;
			buyButtonText.text = string.Format(buyButtonLoc, price);
			Show();
		}

		private string Pluralize(int amount)
		{
			switch (CasesUtil.GetCase(amount))
			{
			case CaseType.DEFAULT:
				return string.Format(chargesAmountPlural1Text.Value, amount);
			case CaseType.ONE:
				return string.Format(chargesAmountSingularText.Value, amount);
			case CaseType.TWO:
				return string.Format(chargesAmountPlural2Text.Value, amount);
			default:
				throw new Exception("ivnalid case");
			}
		}

		public override void Hide()
		{
			base.Hide();
			MainScreenComponent.Instance.OverrideOnBack(delegate
			{
			});
		}
	}
}
