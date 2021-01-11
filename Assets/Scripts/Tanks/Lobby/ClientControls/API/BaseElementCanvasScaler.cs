using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[RequireComponent(typeof(Canvas))]
	[ExecuteInEditMode]
	public class BaseElementCanvasScaler : MonoBehaviour, BaseElementScaleControllerProvider
	{
		private bool resizing;

		private static bool initialized;

		[SerializeField]
		private BaseElementScaleController baseElementScaleController;

		public BaseElementScaleController BaseElementScaleController
		{
			get
			{
				return baseElementScaleController;
			}
			set
			{
				baseElementScaleController = value;
			}
		}

		public static void MarkNeedInitialize()
		{
			initialized = false;
		}

		protected void Awake()
		{
			if (baseElementScaleController != null && !initialized)
			{
				initialized = true;
				baseElementScaleController.Init();
			}
		}

		protected void OnEnable()
		{
		}

		protected void OnRectTransformDimensionsChange()
		{
			if (!resizing && (base.enabled || !Application.isPlaying) && baseElementScaleController != null)
			{
				resizing = true;
				baseElementScaleController.Handle(GetComponent<Canvas>());
				resizing = false;
			}
		}
	}
}
