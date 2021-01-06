using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class HelpOverlayTextComponent : LocalizedControl
	{
		[SerializeField]
		private Text controlsText;
		[SerializeField]
		private Text turretText;
		[SerializeField]
		private Text fireText;
		[SerializeField]
		private Text spaceText;
		[SerializeField]
		private Text orText;
		[SerializeField]
		private Text additionalControlsText;
		[SerializeField]
		private Text modulesText;
		[SerializeField]
		private Text graffitiText;
		[SerializeField]
		private Text selfDestructText;
		[SerializeField]
		private Text helpText;
		[SerializeField]
		private Text exitText;
	}
}
