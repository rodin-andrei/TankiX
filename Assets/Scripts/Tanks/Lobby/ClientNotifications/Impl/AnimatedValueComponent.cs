using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tanks.Lobby.ClientNotifications.Impl
{
	public class AnimatedValueComponent : BehaviourComponent
	{
		public float animationTime;
		public AnimationCurve curve;
		[SerializeField]
		private long startValue;
		[SerializeField]
		private long maximum;
		[SerializeField]
		private long price;
		[SerializeField]
		private Slider upgradeSlider;
		[SerializeField]
		private TextMeshProUGUI upgradeCount;
		[SerializeField]
		private GameObject outline;
		[SerializeField]
		private bool canStart;
	}
}
