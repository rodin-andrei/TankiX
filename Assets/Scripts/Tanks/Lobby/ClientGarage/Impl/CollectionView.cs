using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CollectionView : MonoBehaviour
	{
		public GameObject tierActiveCollectionViewPrefab;
		public GameObject tierPassiveCollectionViewPrefab;
		public GameObject collectionSlotPrefab;
		public SubCollectionView turretCollectionView;
		public SubCollectionView hullCollectionView;
		public Toggle turretToggle;
		public Toggle hullToggle;
	}
}
