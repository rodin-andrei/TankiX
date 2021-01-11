using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientHome.API
{
	public class HomeScreenLocalizedStringsComponent : BehaviourComponent
	{
		[SerializeField]
		private Text playButtonLabel;

		[SerializeField]
		private Text battlesButtonLabel;

		[SerializeField]
		private Text garageButtonLabel;

		[SerializeField]
		private Text questsButtonLabel;

		[SerializeField]
		private Text containersButtonLabel;

		public string PlayButtonLabel
		{
			set
			{
				playButtonLabel.text = value;
			}
		}

		public virtual string BattlesButtonLabel
		{
			set
			{
				battlesButtonLabel.text = value;
			}
		}

		public virtual string GarageButtonLabel
		{
			set
			{
				garageButtonLabel.text = value;
			}
		}

		public virtual string QuestsButtonLabel
		{
			set
			{
				questsButtonLabel.text = value;
			}
		}

		public virtual string ContainersButtonLabel
		{
			set
			{
				containersButtonLabel.text = value;
			}
		}
	}
}
