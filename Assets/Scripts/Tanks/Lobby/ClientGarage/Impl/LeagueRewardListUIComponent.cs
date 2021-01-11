using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LeagueRewardListUIComponent : MonoBehaviour
	{
		[SerializeField]
		private LeagueRewardItem itemPrefab;

		public void Clear()
		{
			base.transform.DestroyChildren();
		}

		public void AddItem(string text, string imageUID)
		{
			GetNewItem(text, imageUID);
		}

		private LeagueRewardItem GetNewItem(string text, string imageUID)
		{
			LeagueRewardItem leagueRewardItem = Object.Instantiate(itemPrefab);
			leagueRewardItem.transform.SetParent(base.transform, false);
			leagueRewardItem.Text = text;
			leagueRewardItem.Icon = imageUID;
			leagueRewardItem.gameObject.SetActive(true);
			return leagueRewardItem;
		}
	}
}
