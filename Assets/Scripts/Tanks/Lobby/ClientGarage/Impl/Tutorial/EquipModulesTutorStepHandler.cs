using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl.Tutorial
{
	public class EquipModulesTutorStepHandler : TutorialStepHandler
	{
		public NewModulesScreenUIComponent modulesScreen;
		[SerializeField]
		private RectTransform popupPositionRect;
		[SerializeField]
		private RectTransform arrowPositionRect;
	}
}
