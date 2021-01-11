using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientControls.API
{
	public class InputPauseObserverComponent : ECSBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, AttachToEntityListener
	{
		private bool inputChanged;

		private float lastChangeTime;

		private Entity entity;

		[SerializeField]
		private float delayInSec;

		[Inject]
		public static UnityTime UnityTime
		{
			get;
			set;
		}

		public void Update()
		{
			if (inputChanged && UnityTime.time - lastChangeTime > delayInSec)
			{
				ScheduleEvent<InputPausedEvent>(entity);
				inputChanged = false;
			}
		}

		private void OnInputValueChange(string arg0)
		{
			inputChanged = true;
			lastChangeTime = UnityTime.time;
		}

		public void AttachedToEntity(Entity entity)
		{
			inputChanged = false;
			this.entity = entity;
			InputField component = GetComponent<InputField>();
			if (component != null)
			{
				component.onValueChanged.AddListener(OnInputValueChange);
				return;
			}
			TMP_InputField component2 = GetComponent<TMP_InputField>();
			if (component2 != null)
			{
				component2.onValueChanged.AddListener(OnInputValueChange);
				component2.onSelect.AddListener(OnInputValueChange);
			}
		}
	}
}
