using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleEffectsInfoComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TextMeshProUGUI effectText;

		[SerializeField]
		private ImageSkin effectIcon;

		[SerializeField]
		private PaletteColorField exceptionalColor;

		[SerializeField]
		private PaletteColorField epicColor;

		[SerializeField]
		private Image staticIcon;

		public ImageSkin EffectIcon
		{
			get
			{
				return effectIcon;
			}
		}

		public string EffectValue
		{
			set
			{
				effectText.text = value;
			}
		}

		public Color ExceptionalColor
		{
			get
			{
				return exceptionalColor;
			}
		}

		public Color EpicColor
		{
			get
			{
				return epicColor;
			}
		}

		public Image StaticIcon
		{
			get
			{
				return staticIcon;
			}
		}

		public TextMeshProUGUI EffectText
		{
			get
			{
				return effectText;
			}
		}
	}
}
