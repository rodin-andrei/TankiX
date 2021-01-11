using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class CarouselComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private CarouselButtonComponent backButton;

		[SerializeField]
		private CarouselButtonComponent frontButton;

		[SerializeField]
		[HideInInspector]
		private int templateIdLow;

		[SerializeField]
		[HideInInspector]
		private int templateIdHigh;

		public long ItemTemplateId
		{
			get
			{
				return ((long)templateIdHigh << 32) | (uint)templateIdLow;
			}
			set
			{
				templateIdLow = (int)(value & 0xFFFFFFFFu);
				templateIdHigh = (int)(value >> 32);
			}
		}

		public TextMeshProUGUI Text
		{
			get
			{
				return text;
			}
		}

		public CarouselButtonComponent BackButton
		{
			get
			{
				return backButton;
			}
		}

		public CarouselButtonComponent FrontButton
		{
			get
			{
				return frontButton;
			}
		}
	}
}
