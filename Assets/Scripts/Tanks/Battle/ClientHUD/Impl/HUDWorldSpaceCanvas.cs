using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class HUDWorldSpaceCanvas : MonoBehaviour
	{
		public Canvas canvas;
		public GameObject nameplatePrefab;
		public Vector3 offset;
		[SerializeField]
		private GameObject damageInfoPrefab;
	}
}
