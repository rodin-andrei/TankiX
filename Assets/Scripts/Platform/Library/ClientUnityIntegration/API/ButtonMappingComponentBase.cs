using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Platform.Library.ClientUnityIntegration.API
{
	[RequireComponent(typeof(Button))]
	public abstract class ButtonMappingComponentBase<T> : EventMappingComponent where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
	{
		private Button button;

		public Button Button
		{
			get
			{
				if (button == null)
				{
					button = GetComponent<Button>();
				}
				return button;
			}
		}

		protected override void Subscribe()
		{
			Button.onClick.AddListener(delegate
			{
				SendEvent<T>();
			});
		}
	}
}
