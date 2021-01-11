using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public abstract class AbstractPriceLabelComponent : BehaviourComponent
	{
		public Color shortageColor = Color.red;

		[SerializeField]
		private GameObject oldPrice;

		[SerializeField]
		private Text oldPriceText;

		public Color DefaultColor
		{
			get;
			set;
		}

		public long Price
		{
			get;
			set;
		}

		public long OldPrice
		{
			get;
			set;
		}

		public Text Text
		{
			get
			{
				return GetComponent<Text>();
			}
		}

		public bool OldPriceVisible
		{
			set
			{
				if (oldPrice != null)
				{
					oldPrice.SetActive(value);
				}
			}
		}

		public string OldPriceText
		{
			set
			{
				if (oldPriceText != null)
				{
					oldPriceText.text = value;
				}
			}
		}

		public Color Color
		{
			get
			{
				return Text.color;
			}
			set
			{
				if (Text.color == DefaultColor)
				{
					Text.color = value;
				}
				DefaultColor = value;
			}
		}

		private void Awake()
		{
			DefaultColor = Text.color;
		}
	}
}
