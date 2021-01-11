using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class ViewUserEmailScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Text yourEmailReplaced;

		[SerializeField]
		private Color emailColor = Color.green;

		public string YourEmailReplaced
		{
			set
			{
				yourEmailReplaced.text = value;
			}
		}

		public string YourEmail
		{
			get;
			set;
		}

		public Color EmailColor
		{
			get
			{
				return emailColor;
			}
		}
	}
}
