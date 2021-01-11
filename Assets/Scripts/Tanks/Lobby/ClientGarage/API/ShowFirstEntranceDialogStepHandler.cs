using System;
using Lobby.ClientGarage.Impl;
using Tanks.Lobby.ClientGarage.Impl;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.API
{
	public class ShowFirstEntranceDialogStepHandler : TutorialStepHandler
	{
		public override void RunStep(TutorialData data)
		{
			base.RunStep(data);
			WelcomeScreenDialog welcomeScreenDialog = UnityEngine.Object.FindObjectOfType<Dialogs60Component>().Get<WelcomeScreenDialog>();
			welcomeScreenDialog.Show();
			welcomeScreenDialog.dialogClosed = (Action)Delegate.Combine(welcomeScreenDialog.dialogClosed, new Action(Complete));
		}

		private void Complete()
		{
			StepComplete();
		}
	}
}
