using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class UserEnergyBarUIComponent : BehaviourComponent
	{
		[SerializeField]
		private float animationSpeed;
		[SerializeField]
		private Slider slider;
		[SerializeField]
		private Slider subSlider;
		[SerializeField]
		private TextMeshProUGUI energyLevel;
	}
}
