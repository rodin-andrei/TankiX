using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class BasePointerComponent : CTFPointerComponent
	{
		public Sprite FlagOnBaseImage;
		public Sprite FlagStolenImage;
		public LocalizedField BaseText;
		public Image Image;
	}
}
