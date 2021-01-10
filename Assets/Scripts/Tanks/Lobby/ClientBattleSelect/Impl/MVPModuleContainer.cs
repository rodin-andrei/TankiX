using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MVPModuleContainer : MonoBehaviour
	{
		[SerializeField]
		private GameObject card;
		[SerializeField]
		private TextMeshProUGUI cardInfo;
		[SerializeField]
		private LocalizedField moduleLevelShortLocalizedField;
	}
}
