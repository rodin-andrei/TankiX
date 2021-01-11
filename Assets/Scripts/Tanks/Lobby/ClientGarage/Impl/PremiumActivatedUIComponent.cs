using System.Collections.Generic;
using Lobby.ClientUserProfile.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientEntrance.API;
using TMPro;
using UnityEngine;

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

		public void ShowPrem(List<Animator> animators, bool premWithQuest, int daysCount, bool promo = false)
		{
			premIcon.SetActive(!premWithQuest);
			xpremIcon.SetActive(premWithQuest);
			days.text = string.Format(premDays, daysCount, CasesUtil.GetLocalizedCase(dayLocalizationCases, daysCount));
			if (promo)
			{
				title.text = promoPremTitle;
				reason.text = string.Format(promoPremText, SelfUserComponent.SelfUser.GetComponent<UserUidComponent>().Uid);
				reason.gameObject.SetActive(true);
			}
			else
			{
				title.text = usualPremTitle;
			}
			Show(animators);
		}
	}
}
