using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Image))]
	public class TankBuilderMaterialAlphaController : BehaviourComponent
	{
		private CanvasGroup[] canvasGroups;

		private Material material;

		private void Awake()
		{
			canvasGroups = GetComponentsInParent<CanvasGroup>();
			Image component = GetComponent<Image>();
			Material material2 = (this.material = (component.material = new Material(component.material)));
		}

		private void OnEnable()
		{
			SetAlpha();
		}

		private void Update()
		{
			SetAlpha();
		}

		private void SetAlpha()
		{
			float num = 1f;
			CanvasGroup[] array = canvasGroups;
			foreach (CanvasGroup canvasGroup in array)
			{
				num *= canvasGroup.alpha;
			}
			material.SetFloat("alpha", 1f - num);
		}
	}
}
