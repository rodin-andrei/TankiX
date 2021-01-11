namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CaseEjectorMovementTriggerComponent : AnimationTriggerComponent
	{
		private void OnCaseEjectorOpen()
		{
			ProvideEvent<CaseEjectorOpenEvent>();
		}

		private void OnCaseEjectorClose()
		{
			ProvideEvent<CaseEjectorCloseEvent>();
		}
	}
}
