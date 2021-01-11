using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class SpecialOfferWorthItComponent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI worthItText;

		[SerializeField]
		private LocalizedField worthItLocalizedField;

		public void SetLabel(int labelPercentage)
		{
			if (labelPercentage > 0)
			{
				base.gameObject.SetActive(true);
				worthItText.text = string.Format(worthItLocalizedField.Value, labelPercentage);
			}
			else
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
