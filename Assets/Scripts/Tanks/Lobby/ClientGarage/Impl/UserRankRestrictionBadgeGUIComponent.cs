using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UserRankRestrictionBadgeGUIComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private ImageListSkin imageListSkin;

		public void SetRank(int rank)
		{
			imageListSkin.SelectSprite(rank.ToString());
		}
	}
}
