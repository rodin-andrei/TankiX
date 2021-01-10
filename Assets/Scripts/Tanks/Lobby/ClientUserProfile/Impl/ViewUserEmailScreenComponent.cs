using Tanks.Lobby.ClientNavigation.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ViewUserEmailScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Text yourEmailReplaced;
		[SerializeField]
		private Color emailColor;
	}
}
