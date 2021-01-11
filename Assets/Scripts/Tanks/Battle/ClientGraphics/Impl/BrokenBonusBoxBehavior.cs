using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BrokenBonusBoxBehavior : MonoBehaviour
	{
		[SerializeField]
		private GameObject brokenBonusGameObject;

		public GameObject BrokenBonusGameObject
		{
			get
			{
				return brokenBonusGameObject;
			}
		}
	}
}
