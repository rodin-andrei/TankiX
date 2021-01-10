using UnityEngine;

namespace LeopotamGroup.Pooling
{
	public class PoolContainer : MonoBehaviour
	{
		[SerializeField]
		private string _prefabPath;
		public GameObject CustomPrefab;
		[SerializeField]
		private Transform _itemsRoot;
	}
}
