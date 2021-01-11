using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BackhitDamageTutorialTrigger : MonoBehaviour
	{
		[SerializeField]
		private float showDelay = 60f;

		[HideInInspector]
		public bool canShow;

		private float timer;

		private void OnEnable()
		{
			timer = 0f;
		}

		private void Update()
		{
			timer += Time.deltaTime;
			if (timer >= showDelay)
			{
				canShow = true;
				GetComponent<TutorialShowTriggerComponent>().Triggered();
				base.enabled = false;
			}
		}
	}
}
