using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Lobby.ClientUserProfile.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	[SerialVersionUID(635883805937045890L)]
	public class ScoreTableUserLabelIndicatorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject userLabel;

		public void Awake()
		{
			userLabel = UserLabelBuilder.CreateDefaultLabel();
			userLabel.transform.SetParent(base.gameObject.transform, false);
		}
	}
}
