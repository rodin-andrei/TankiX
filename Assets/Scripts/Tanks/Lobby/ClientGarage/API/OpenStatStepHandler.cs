using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.API
{
	public class OpenStatStepHandler : TutorialStepHandler
	{
		[SerializeField]
		private Button statButton;

		public override void RunStep(TutorialData data)
		{
			base.RunStep(data);
			statButton.onClick.Invoke();
			StepComplete();
		}
	}
}
