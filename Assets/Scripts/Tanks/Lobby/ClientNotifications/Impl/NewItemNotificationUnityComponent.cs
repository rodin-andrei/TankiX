using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using Tanks.Battle.ClientGraphics.Impl;
using Tanks.Lobby.ClientGarage.Impl;

namespace Tanks.Lobby.ClientNotifications.Impl
{
	public class NewItemNotificationUnityComponent : BehaviourComponent
	{
		public Slider upgradeSlider;
		public AnimatedValueComponent upgradeAnimator;
		public int count;
		[SerializeField]
		private TextMeshProUGUI headerElement;
		[SerializeField]
		private GameObject containerContent;
		[SerializeField]
		private TextMeshProUGUI itemNameElement;
		[SerializeField]
		private ImageSkin itemIconSkin;
		[SerializeField]
		private ImageSkin resourceIconSkin;
		[SerializeField]
		private GameObject itemContent;
		[SerializeField]
		private GameObject resourceContent;
		[SerializeField]
		private Image borderImg;
		[SerializeField]
		private TextMeshProUGUI rarityNameElement;
		[SerializeField]
		private GameObject rareEffect;
		[SerializeField]
		private GameObject epicEffect;
		[SerializeField]
		private GameObject legendaryEffect;
		[SerializeField]
		private LocalizedField commonText;
		[SerializeField]
		private LocalizedField rareText;
		[SerializeField]
		private LocalizedField epicText;
		[SerializeField]
		private LocalizedField legendaryText;
		[SerializeField]
		public Material[] cardMaterial;
		public OutlineObject outline;
		public ModuleCardView view;
		[SerializeField]
		private GameObject cardElement;
	}
}
