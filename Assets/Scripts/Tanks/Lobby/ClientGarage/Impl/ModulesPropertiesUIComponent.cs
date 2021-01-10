using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModulesPropertiesUIComponent : BehaviourComponent
	{
		[SerializeField]
		private UpgradePropertyUI propertyUIPreafab;
		[SerializeField]
		private RectTransform scrollContent;
	}
}
