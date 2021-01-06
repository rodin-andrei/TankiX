using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageListItemContentComponent : LocalizedControl
	{
		[SerializeField]
		private Text header;
		[SerializeField]
		private Text count;
		[SerializeField]
		private Text proficiencyLevel;
		[SerializeField]
		private ProgressBar progressBar;
		[SerializeField]
		private GameObject priceGameObject;
		[SerializeField]
		private GameObject xPriceGameObject;
		[SerializeField]
		private GameObject upgradeGameObject;
		[SerializeField]
		private GameObject arrow;
		[SerializeField]
		private Graphic unlockGraphic;
		[SerializeField]
		private GameObject previewContainer;
		[SerializeField]
		private GameObject previewPrefab;
		[SerializeField]
		private Text rareText;
		[SerializeField]
		private GameObject saleLabel;
		[SerializeField]
		private Text saleLabelText;
	}
}
