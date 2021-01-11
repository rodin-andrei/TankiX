using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ShowArmsRaceIntroEvent : Event
	{
		private ConfirmDialogComponent dialog;

		public ConfirmDialogComponent Dialog
		{
			get
			{
				return dialog;
			}
			set
			{
				dialog = value;
			}
		}
	}
}
