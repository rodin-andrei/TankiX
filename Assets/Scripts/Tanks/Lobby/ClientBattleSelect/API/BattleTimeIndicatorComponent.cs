using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	[SerialVersionUID(1447751145383L)]
	public class BattleTimeIndicatorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text timeText;

		[SerializeField]
		private ProgressBar timeProgressBar;

		public string Time
		{
			get
			{
				return timeText.text;
			}
			set
			{
				timeText.text = value;
			}
		}

		public float Progress
		{
			get
			{
				return timeProgressBar.ProgressValue;
			}
			set
			{
				timeProgressBar.ProgressValue = value;
			}
		}
	}
}
