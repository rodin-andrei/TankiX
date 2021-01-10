using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PremiumActivatedUIComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private GameObject premIcon;
		[SerializeField]
		private GameObject xpremIcon;
		[SerializeField]
		private TextMeshProUGUI title;
		[SerializeField]
		private TextMeshProUGUI reason;
		[SerializeField]
		private TextMeshProUGUI days;
		[SerializeField]
		private LocalizedField promoPremTitle;
		[SerializeField]
		private LocalizedField promoPremText;
		[SerializeField]
		private LocalizedField usualPremTitle;
		[SerializeField]
		private LocalizedField premDays;
		[SerializeField]
		private LocalizedField dayLocalizationCases;
	}
}
