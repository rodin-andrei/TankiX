using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class CountingBadgeComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI counter;

		public int Count
		{
			set
			{
				counter.text = value.ToString();
			}
		}

		public void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
		}
	}
}
