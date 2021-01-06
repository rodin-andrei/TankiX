using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class EulaDialog : ConfirmDialogComponent
	{
		[SerializeField]
		private LocalizedField fileName;
		[SerializeField]
		private TextMeshProUGUI pageLabel;
		[SerializeField]
		private LocalizedField pageLocalizedField;
		[SerializeField]
		private TextMeshProUGUI text;
		[SerializeField]
		private GameObject prevPage;
		[SerializeField]
		private GameObject nextPage;
		[SerializeField]
		private GameObject pageButtons;
		[SerializeField]
		private GameObject agreeButton;
		[SerializeField]
		private GameObject loadingIndicator;
	}
}
