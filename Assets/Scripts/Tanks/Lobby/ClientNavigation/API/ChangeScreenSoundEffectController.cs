using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientNavigation.API
{
	[RequireComponent(typeof(Animator))]
	public class ChangeScreenSoundEffectController : UISoundEffectController
	{
		private const string HANDLER_NAME = "ChangeScreen";

		public override string HandlerName
		{
			get
			{
				return "ChangeScreen";
			}
		}

		private void OnChangeScreen()
		{
			PlaySoundEffect();
		}
	}
}
