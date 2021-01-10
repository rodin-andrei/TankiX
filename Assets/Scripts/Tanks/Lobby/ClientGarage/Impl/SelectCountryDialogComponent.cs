using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SelectCountryDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private ScrollRect scrollRect;
		[SerializeField]
		private SelectCountryItem itemPrefab;
		[SerializeField]
		private TMP_InputField searchInput;
	}
}
