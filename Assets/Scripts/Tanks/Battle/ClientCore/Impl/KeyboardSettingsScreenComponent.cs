using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class KeyboardSettingsScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject defaultButton;
		[SerializeField]
		private GameObject oneKeyOnFewActionsTextLabel;
	}
}
