using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

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

		public string ControlsText
		{
			set
			{
				controlsText.text = value;
			}
		}

		public string TurretText
		{
			set
			{
				turretText.text = value;
			}
		}

		public string FireText
		{
			set
			{
				fireText.text = value;
			}
		}

		public string SpaceText
		{
			set
			{
				spaceText.text = value;
			}
		}

		public string OrText
		{
			set
			{
				orText.text = value;
			}
		}

		public string AdditionalControlsText
		{
			set
			{
				additionalControlsText.text = value;
			}
		}

		public string ModulesText
		{
			set
			{
				modulesText.text = value;
			}
		}

		public string GraffitiText
		{
			set
			{
				graffitiText.text = value;
			}
		}

		public string SelfDestructText
		{
			set
			{
				selfDestructText.text = value;
			}
		}

		public string HelpText
		{
			set
			{
				helpText.text = value;
			}
		}

		public string ExitText
		{
			set
			{
				exitText.text = value;
			}
		}
	}
}
