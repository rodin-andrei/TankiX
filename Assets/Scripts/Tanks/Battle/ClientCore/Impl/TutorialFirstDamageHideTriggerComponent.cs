using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class TutorialFirstDamageHideTriggerComponent : TutorialHideTriggerComponent
	{
		[SerializeField]
		private float showTime = 30f;

		private float timer;

		[Inject]
		public static InputManager InputManager
		{
			get;
			set;
		}

		private void OnEnable()
		{
			timer = 0f;
		}

		protected void Update()
		{
			if (!triggered)
			{
				timer += Time.deltaTime;
				if (InputManager.GetActionKeyDown(InventoryAction.INVENTORY_SLOT2) || timer >= showTime)
				{
					Triggered();
				}
			}
		}
	}
}
