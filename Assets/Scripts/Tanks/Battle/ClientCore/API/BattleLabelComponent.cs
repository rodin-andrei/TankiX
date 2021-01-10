using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class BattleLabelComponent : EntityBehaviour
	{
		[SerializeField]
		private long battleId;
		[SerializeField]
		private GameObject map;
		[SerializeField]
		private GameObject mode;
		[SerializeField]
		private GameObject battleIcon;
	}
}
