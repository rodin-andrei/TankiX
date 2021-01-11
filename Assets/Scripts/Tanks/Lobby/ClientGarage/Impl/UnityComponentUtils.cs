using System.Linq;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public static class UnityComponentUtils
	{
		public static T GetComponentInChildrenIncludeInactive<T>(this MonoBehaviour monoBehaviour) where T : MonoBehaviour
		{
			return monoBehaviour.gameObject.GetComponentInChildrenIncludeInactive<T>();
		}

		public static T GetComponentInChildrenIncludeInactive<T>(this GameObject go) where T : MonoBehaviour
		{
			return go.GetComponentsInChildren<T>(true).Single();
		}
	}
}
