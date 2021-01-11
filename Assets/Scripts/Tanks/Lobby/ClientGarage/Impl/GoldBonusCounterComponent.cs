using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GoldBonusCounterComponent : BehaviourComponent
	{
		[SerializeField]
		private Text count;

		public void SetCount(long count)
		{
			this.count.text = count.ToString();
		}
	}
}
