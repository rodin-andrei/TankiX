using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CommonMapEffectBehaviour : MonoBehaviour
	{
		[SerializeField]
		private GameObject commonMapEffectPrefab;

		public GameObject CommonMapEffectPrefab
		{
			get
			{
				return commonMapEffectPrefab;
			}
		}
	}
}
