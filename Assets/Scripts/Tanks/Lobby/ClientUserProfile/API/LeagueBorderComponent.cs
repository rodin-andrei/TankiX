using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class LeagueBorderComponent : BehaviourComponent
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

		public void SetLeague(int league)
		{
			imageListSkin.gameObject.SetActive(true);
			imageListSkin.SelectSprite(league.ToString());
		}
	}
}
