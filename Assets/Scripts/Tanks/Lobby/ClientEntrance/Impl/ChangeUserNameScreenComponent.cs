using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class ChangeUserNameScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private Text inputHint;

		[SerializeField]
		private Text continueButton;

		[SerializeField]
		private Text reservedNameHint;

		public string InputHint
		{
			set
			{
				inputHint.text = value;
			}
		}

		public string ContinueButton
		{
			set
			{
				continueButton.text = value;
			}
		}

		public string ReservedNameHint
		{
			set
			{
				reservedNameHint.text = value;
			}
		}
	}
}
