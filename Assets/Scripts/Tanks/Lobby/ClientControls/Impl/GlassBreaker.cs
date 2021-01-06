using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientControls.Impl
{
	public class GlassBreaker : MonoBehaviour
	{
		public GameObject[] prefabs;
		[SerializeField]
		private List<RectTransform> glassTransforms;
	}
}
