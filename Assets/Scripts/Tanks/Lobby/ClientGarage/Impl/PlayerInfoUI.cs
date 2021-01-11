using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

		[HideInInspector]
		public long ownerId;

		[HideInInspector]
		public long battleId;

		public void Init(long battleId, int position, int rank, string uid, int kills, int score, int deaths, Color color, long hull, long turret, long ownerId, bool isSelf, bool containerLeft, bool containerRight = false)
		{
			Debug.LogError("sad", base.gameObject);
			background.color = color;
			this.rank.SelectSprite(rank.ToString());
			this.uid.text = uid;
			this.kills.text = kills.ToString();
			this.deaths.text = deaths.ToString();
			this.hull.text = "<sprite name=\"" + hull + "\">";
			this.turret.text = "<sprite name=\"" + turret + "\">";
			this.ownerId = ownerId;
			this.battleId = battleId;
			if (this.score != null)
			{
				this.score.text = score.ToStringSeparatedByThousands();
			}
			SetButtonState(isSelf);
		}

		private void SetButtonState(bool isSelf)
		{
			if (interactionsButton != null)
			{
				interactionsButton.interactable = !isSelf;
			}
			else
			{
				Debug.LogError("Button reference wasn't set in " + base.gameObject.name);
			}
		}
	}
}
