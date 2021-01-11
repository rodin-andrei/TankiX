using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class UserInfoUIComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject defaultInfo;

		[SerializeField]
		private GameObject squadInfo;

		public void SwitchSquadInfo(bool value)
		{
			squadInfo.SetActive(value);
			defaultInfo.SetActive(!value);
		}
	}
}
