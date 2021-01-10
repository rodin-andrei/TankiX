using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class SpecialOfferWorthItComponent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI worthItText;
		[SerializeField]
		private LocalizedField worthItLocalizedField;
	}
}
