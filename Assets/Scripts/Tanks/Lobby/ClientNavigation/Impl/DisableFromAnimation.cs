using System.Collections;
using UnityEngine;

namespace Tanks.Lobby.ClientNavigation.Impl
{
	public class DisableFromAnimation : MonoBehaviour
	{
		public void DisableGameObjectFromAnimation()
		{
			StartCoroutine(DisableGameObjectOnEndOfFrame());
		}

		private IEnumerator DisableGameObjectOnEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			base.gameObject.SetActive(false);
		}
	}
}
