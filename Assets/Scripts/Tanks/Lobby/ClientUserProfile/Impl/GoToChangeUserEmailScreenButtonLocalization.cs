using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class GoToChangeUserEmailScreenButtonLocalization : LocalizedControl
	{
		[SerializeField]
		private Text text;

		public override string YamlKey
		{
			get
			{
				return "changeEmailButton";
			}
		}

		public string Text
		{
			set
			{
				text.text = value.ToUpper();
			}
		}
	}
}
