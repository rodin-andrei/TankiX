using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class TextMappingComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private Text text;

		private Text TextComponent
		{
			get
			{
				if (text == null)
				{
					text = GetComponent<Text>();
				}
				return text;
			}
		}

		public virtual string Text
		{
			get
			{
				return TextComponent.text;
			}
			set
			{
				TextComponent.text = value;
			}
		}
	}
}
