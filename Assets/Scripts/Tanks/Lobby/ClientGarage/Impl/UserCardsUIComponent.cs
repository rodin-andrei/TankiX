using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UserCardsUIComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text[] resourceCountTexts;

		public void SetCardsCount(long type, long count)
		{
			int num = 0;
			resourceCountTexts[num].text = count.ToString();
		}

		public void ResetCardsCount()
		{
			SetCardsCount(0L, 0L);
		}
	}
}
