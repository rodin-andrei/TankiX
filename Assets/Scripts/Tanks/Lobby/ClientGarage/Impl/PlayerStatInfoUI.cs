using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PlayerStatInfoUI : MonoBehaviour
	{
		[SerializeField]
		private ImageListSkin imageListSkin;
		[SerializeField]
		private TextMeshProUGUI uid;
		[SerializeField]
		private ImageListSkin league;
		[SerializeField]
		private ImageSkin avatar;
		[SerializeField]
		private Text containerLeftMultiplicator;
		[SerializeField]
		private TextMeshProUGUI hull;
		[SerializeField]
		private TextMeshProUGUI turret;
		[SerializeField]
		private TextMeshProUGUI kills;
		[SerializeField]
		private TextMeshProUGUI score;
		[SerializeField]
		private Button interactionsButton;
		public long userId;
		public long battleId;
		[SerializeField]
		private Text containerRightMultiplicator;
	}
}
