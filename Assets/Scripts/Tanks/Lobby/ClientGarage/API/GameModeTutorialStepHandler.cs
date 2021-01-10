using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.API
{
	public class GameModeTutorialStepHandler : TutorialStepHandler
	{
		[SerializeField]
		private TutorialShowTriggerComponent nextStepTrigger;
		[SerializeField]
		private Transform buttonContainer;
	}
}
