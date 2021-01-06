using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class MainHUDVersionSwitcher : MonoBehaviour
	{
		[SerializeField]
		private RectTransform mainInfoRect;
		[SerializeField]
		private RectTransform inventoryRect;
		[SerializeField]
		private RectTransform effectsRect;
		[SerializeField]
		private RectTransform chatRect;
		[SerializeField]
		private GameObject playerAvatar;
		[SerializeField]
		private GameObject hpBarV1;
		[SerializeField]
		private GameObject hpBarV2;
		[SerializeField]
		private GameObject energyBarV1;
		[SerializeField]
		private GameObject energyBarV2;
		[SerializeField]
		private GameObject effectsTopImage;
		[SerializeField]
		private GameObject inventoryTopImage;
		[SerializeField]
		private GameObject bottomLongLineImage;
		[SerializeField]
		private GameObject killAssistLogV1;
		[SerializeField]
		private GameObject killAssistLogV2;
		[SerializeField]
		private GameObject battleChatInput;
		public bool specMode;
	}
}
