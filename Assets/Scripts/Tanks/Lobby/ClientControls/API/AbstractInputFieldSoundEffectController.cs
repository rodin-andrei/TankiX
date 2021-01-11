using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientControls.API
{
	public abstract class AbstractInputFieldSoundEffectController : UISoundEffectController, ISelectHandler, IDeselectHandler, IEventSystemHandler
	{
		private bool selected;

		protected bool Selected
		{
			get
			{
				return selected;
			}
		}

		private void OnEnable()
		{
			selected = false;
		}

		public void OnSelect(BaseEventData eventData)
		{
			selected = true;
		}

		public void OnDeselect(BaseEventData eventData)
		{
			selected = false;
		}
	}
}
