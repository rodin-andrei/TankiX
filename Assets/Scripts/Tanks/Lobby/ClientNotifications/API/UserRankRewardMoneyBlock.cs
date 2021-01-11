using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientNotifications.API
{
	public class UserRankRewardMoneyBlock : MonoBehaviour
	{
		[SerializeField]
		private Text moneyRewardField;

		public Text MoneyRewardField
		{
			get
			{
				return moneyRewardField;
			}
		}
	}
}
