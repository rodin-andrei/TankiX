namespace Tanks.Lobby.ClientControls.API
{
	public class ListItemSelectSoundEffectController : UISoundEffectController
	{
		public override string HandlerName
		{
			get
			{
				return "ListItemSelect";
			}
		}

		private void OnItemSelect(ListItem listItem)
		{
			PlaySoundEffect();
		}
	}
}
