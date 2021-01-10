using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientGarage.Impl;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl.Tutorial
{
	public class UpgradeModuleTutorStep11Handler : TutorialStepHandler
	{
		public NewModulesScreenUIComponent modulesScreen;
		public List<GameObject> highlightedObjects;
		[SerializeField]
		private RectTransform popupPositionRect;
	}
}
