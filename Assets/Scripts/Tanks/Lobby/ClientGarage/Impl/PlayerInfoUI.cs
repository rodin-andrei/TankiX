using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PlayerInfoUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI uid;
		[SerializeField]
		private Text containerLeftMultiplicator;
		[SerializeField]
		private ImageListSkin rank;
		[SerializeField]
		private Text containerRightMultiplicator;
		[SerializeField]
		private TextMeshProUGUI kills;
		[SerializeField]
		private TextMeshProUGUI deaths;
		[SerializeField]
		private TextMeshProUGUI score;
		[SerializeField]
		private TextMeshProUGUI hull;
		[SerializeField]
		private TextMeshProUGUI turret;
		[SerializeField]
		private Graphic background;
		[SerializeField]
		private Button interactionsButton;
		public long ownerId;
		public long battleId;
	}
}
