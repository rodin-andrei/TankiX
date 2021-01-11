using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class UIElementHomeSoundEffectController : UISoundEffectController
	{
		public override string HandlerName
		{
			get
			{
				return "Home";
			}
		}

		private void OnDisable()
		{
			if (alive)
			{
				PlayHomeSoundEffectIfNeeded();
			}
		}

		private void PlayHomeSoundEffectIfNeeded()
		{
			if (Input.GetKey(KeyCode.Home))
			{
				PlaySoundEffect();
			}
		}
	}
}
