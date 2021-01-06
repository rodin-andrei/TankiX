using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LoginRewardAllItemsContainer : MonoBehaviour
	{
		public int currentDay;
		[SerializeField]
		private LoginRewardItemUI itemPrefab;
		[SerializeField]
		private LoginRewardDialog dialog;
	}
}
