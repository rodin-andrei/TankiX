using UnityEngine;
using System.Collections.Generic;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class DailyBonusMapView : MonoBehaviour
	{
		public List<GameObject> zones;
		public GameObject bonusElementPrefab;
		public List<MapViewBonusElement> bonusElements;
		public MapViewBonusElement selectedBonusElement;
		public ImageListSkin back;
	}
}
