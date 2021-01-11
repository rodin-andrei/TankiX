namespace Tanks.Lobby.ClientControls.API
{
	public class TabSoundController : UISoundEffectController
	{
		private string _handlerName;

		public override string HandlerName
		{
			get
			{
				return _handlerName;
			}
		}
	}
}
