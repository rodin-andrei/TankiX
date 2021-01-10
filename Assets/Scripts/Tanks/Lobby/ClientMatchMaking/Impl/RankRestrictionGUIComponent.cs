using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class RankRestrictionGUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI rankName;
		[SerializeField]
		private ImageListSkin imageListSkin;
	}
}
