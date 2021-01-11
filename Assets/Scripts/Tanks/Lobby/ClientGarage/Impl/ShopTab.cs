using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ShopTab : Tab
	{
		[SerializeField]
		private bool showBackground = true;

		[SerializeField]
		private Animator backgroundAnimator;

		protected override void OnEnable()
		{
			base.OnEnable();
			ContainersUI component = base.gameObject.GetComponent<ContainersUI>();
			if (component != null)
			{
				component.OnEnable();
			}
			backgroundAnimator.SetBool("Background", showBackground);
		}

		public override void Hide()
		{
			MainScreenComponent.Instance.ClearOnBackOverride();
			base.Hide();
		}
	}
}
