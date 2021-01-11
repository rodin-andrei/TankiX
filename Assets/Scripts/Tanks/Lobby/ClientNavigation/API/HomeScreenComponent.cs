using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class HomeScreenComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text uidText;

		[SerializeField]
		private GameObject cbqBadge;

		[SerializeField]
		private GameObject battleLobbyScreen;

		public virtual string UidText
		{
			get
			{
				return uidText.text;
			}
			set
			{
				uidText.text = value;
			}
		}

		public virtual GameObject CbqBadge
		{
			get
			{
				return cbqBadge;
			}
		}

		public virtual GameObject BattleLobbyScreen
		{
			get
			{
				return battleLobbyScreen;
			}
		}
	}
}
