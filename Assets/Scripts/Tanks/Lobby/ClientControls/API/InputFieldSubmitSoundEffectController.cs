using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class InputFieldSubmitSoundEffectController : AbstractInputFieldSoundEffectController
	{
		public override string HandlerName
		{
			get
			{
				return "Submit";
			}
		}

		private void OnGUI()
		{
			if (base.Selected && Event.current.type == EventType.KeyDown && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
			{
				PlaySoundEffect();
			}
		}
	}
}
