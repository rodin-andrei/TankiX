using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class StarterPackScreenUIComponent : PurchaseItemComponent
	{
		[SerializeField]
		private StarterPackElementComponent elementPrefab;
		[SerializeField]
		private RectTransform mainPreviewContainer;
		[SerializeField]
		private RectTransform previewContainer;
		[SerializeField]
		private TextMeshProUGUI title;
		[SerializeField]
		private TextMeshProUGUI description;
		[SerializeField]
		private TextMeshProUGUI hurryUp;
		[SerializeField]
		private TextMeshProUGUI newPrice;
		[SerializeField]
		private TextMeshProUGUI mainItemDescription;
	}
}
