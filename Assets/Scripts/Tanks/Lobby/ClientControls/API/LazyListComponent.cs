using UnityEngine.EventSystems;
using UnityEngine;
using Platform.Library.ClientUnityIntegration.API;

namespace Tanks.Lobby.ClientControls.API
{
	public class LazyListComponent : UIBehaviour
	{
		[SerializeField]
		private ListItem itemPrefab;
		[SerializeField]
		private EntityBehaviour entityBehaviour;
		[SerializeField]
		private float itemMinSize;
		[SerializeField]
		private float spacing;
		[SerializeField]
		private bool vertical;
		[SerializeField]
		private bool noScroll;
		[SerializeField]
		private float itemScrollTime;
	}
}
