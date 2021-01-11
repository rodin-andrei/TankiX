using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientControls.API
{
	public class UIElementSubmitSoundEffectController : UISoundEffectController, IPointerClickHandler, ISubmitHandler, IEventSystemHandler
	{
		private const string HANDLER_NAME = "ClickAndSubmit";

		public override string HandlerName
		{
			get
			{
				return "ClickAndSubmit";
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (base.gameObject.IsInteractable())
			{
				PlaySoundEffect();
			}
		}

		public void OnSubmit(BaseEventData eventData)
		{
			PlaySoundEffect();
		}
	}
}
