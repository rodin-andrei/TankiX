using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MVPOtherStatComponent : MonoBehaviour
	{
		[SerializeField]
		private MVPStatElementComponent flagsDelivered;
		[SerializeField]
		private MVPStatElementComponent flagsReturned;
		[SerializeField]
		private MVPStatElementComponent damage;
		[SerializeField]
		private MVPStatElementComponent killStreak;
		[SerializeField]
		private MVPStatElementComponent bonuseTaken;
	}
}
