using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TutorialWeaponHideTrigger : TutorialHideTriggerComponent
	{
		[SerializeField]
		private float showTime = 5f;

		private float timer;

		private void OnEnable()
		{
			timer = 0f;
		}

		private void Update()
		{
			timer += Time.deltaTime;
			if (timer >= showTime)
			{
				Triggered();
			}
		}
	}
}
