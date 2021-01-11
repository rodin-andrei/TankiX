using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class RankIconComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private ImageListSkin imageListSkin;

		public ImageListSkin ImageListSkin
		{
			get
			{
				return imageListSkin;
			}
		}

		public void SetRank(int rank)
		{
			imageListSkin.gameObject.SetActive(true);
			imageListSkin.SelectSprite(rank.ToString());
		}
	}
}
