using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TeleportHeaderView : MonoBehaviour
	{
		public LocalizedField lvl1;
		public LocalizedField lvl2;
		public LocalizedField lvl3;
		public LocalizedField lvl4;
		public LocalizedField lvl5;
		public LocalizedField broken;
		public LocalizedField hint;
		public LocalizedField brokenHint;
		public TextMeshProUGUI labelText;
		public TextMeshProUGUI hintText;
	}
}
