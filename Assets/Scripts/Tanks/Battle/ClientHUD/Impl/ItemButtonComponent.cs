using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class ItemButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private CooldownAnimation cooldown;
		[SerializeField]
		private PaletteColorField epicColor;
		[SerializeField]
		private PaletteColorField exceptionalColor;
		[SerializeField]
		private ImageSkin icon;
		[SerializeField]
		private TextMeshProUGUI keyBind;
		[SerializeField]
		private Animator lockByEMPAnimator;
		[SerializeField]
		private Color CDColor;
		[SerializeField]
		private Color FullCDColor;
		[SerializeField]
		private Color LowCDColor;
		[SerializeField]
		private Color RageCDColor;
		[SerializeField]
		private Image CDFill;
		[SerializeField]
		private GameObject barRoot;
		[SerializeField]
		private AmmunitionBar ammunitionBarPrefab;
		[SerializeField]
		private AmmunitionBar[] ammunitionBars;
		public bool ammunitionCountWasIncreased;
		public bool isRage;
		public float CooldownCoeff;
	}
}
