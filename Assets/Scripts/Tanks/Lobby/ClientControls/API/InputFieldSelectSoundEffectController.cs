using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientControls.API
{
	public class InputFieldSelectSoundEffectController : AbstractInputFieldSoundEffectController, IPointerDownHandler, IEventSystemHandler
	{
		public override string HandlerName
		{
			get
			{
				return "Select";
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (!base.Selected)
			{
				PlaySoundEffect();
			}
		}
	}
}
