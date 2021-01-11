using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[ExecuteInEditMode]
	public class ResizeDispatcher : MonoBehaviour
	{
		[SerializeField]
		private List<ResizeListener> listeners;

		private void OnEnable()
		{
			OnRectTransformDimensionsChange();
		}

		private void OnRectTransformDimensionsChange()
		{
			RectTransform component = GetComponent<RectTransform>();
			foreach (ResizeListener listener in listeners)
			{
				listener.OnResize(component);
			}
		}
	}
}
