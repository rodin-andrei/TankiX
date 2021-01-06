using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class FlagPointerComponent : CTFPointerComponent
	{
		public LocalizedField FlagOnTheGroundText;
		public LocalizedField FlagCapturedText;
		public GameObject pointer;
	}
}
