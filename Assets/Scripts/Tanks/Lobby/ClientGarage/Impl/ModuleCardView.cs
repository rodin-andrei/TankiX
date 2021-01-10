using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleCardView : MonoBehaviour
	{
		[SerializeField]
		private Material[] cardMaterial;
		[SerializeField]
		private TextMeshProUGUI moduleLevel;
		[SerializeField]
		private TextMeshProUGUI moduleName;
		[SerializeField]
		private TextMeshProUGUI moduleCount;
		[SerializeField]
		private Color[] tierColor;
		[SerializeField]
		private Image background;
		public ImageSkin[] imageSkins;
		public Sprite[] tierBackgrounds;
		public MeshRenderer meshRenderer;
		public int tierNumber;
	}
}
