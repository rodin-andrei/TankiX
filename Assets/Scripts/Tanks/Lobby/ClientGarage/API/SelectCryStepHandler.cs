using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.API
{
	public class SelectCryStepHandler : TutorialStepHandler
	{
		[SerializeField]
		private RectTransform popupPositionRect;

		[SerializeField]
		private RectTransform highlightedRects;

		public override void RunStep(TutorialData data)
		{
			base.RunStep(data);
			CheckBoughtItemEvent checkBoughtItemEvent = new CheckBoughtItemEvent(data.TutorialStep.GetComponent<TutorialSelectItemDataComponent>().itemMarketId);
			TutorialStepHandler.EngineService.Engine.ScheduleEvent(checkBoughtItemEvent, TutorialStepHandler.EngineService.EntityStub);
			if (checkBoughtItemEvent.TutorialItemAlreadyBought)
			{
				TutorialStepHandler.EngineService.Engine.ScheduleEvent<CompleteTutorialByEscEvent>(data.TutorialStep);
				Complete();
				return;
			}
			data.PopupPositionRect = popupPositionRect;
			data.ContinueOnClick = false;
			TutorialCanvas.Instance.Show(data, true, new GameObject[1]
			{
				highlightedRects.gameObject
			});
			base.gameObject.SetActive(true);
			Invoke("Complete", 1f);
		}

		private void Complete()
		{
			StepComplete();
		}
	}
}
