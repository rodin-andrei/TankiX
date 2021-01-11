using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class MakeKeyboardSettingsButton : MonoBehaviour
	{
		[ContextMenu("Make")]
		public void Make()
		{
			Debug.Log("Make for " + base.gameObject.name);
			MakeAllNotIneractable makeAllNotIneractable = base.gameObject.AddComponent<MakeAllNotIneractable>();
			makeAllNotIneractable.MakeNotInteractable();
			Object.DestroyImmediate(makeAllNotIneractable);
			Debug.Log("Not interactable");
			InputField[] componentsInChildren = GetComponentsInChildren<InputField>();
			InputField[] array = componentsInChildren;
			foreach (InputField inputField in array)
			{
				Debug.Log(inputField.name);
				GameObject gameObject = new GameObject("Button");
				gameObject.transform.SetParent(base.transform, false);
				gameObject.AddComponent<Button>();
				gameObject.AddComponent<CursorSwitcher>();
				gameObject.AddComponent<InputFieldParentButton>();
				Image image = gameObject.AddComponent<Image>();
				image.color = Color.clear;
				RectTransform component = inputField.GetComponent<RectTransform>();
				RectTransform component2 = gameObject.GetComponent<RectTransform>();
				component2.pivot = component.pivot;
				component2.anchorMax = component.anchorMax;
				component2.anchorMin = component.anchorMin;
				component2.anchoredPosition = component.anchoredPosition;
				component2.offsetMin = component.offsetMin;
				component2.offsetMax = component.offsetMax;
				inputField.transform.SetParent(gameObject.transform, false);
				component.anchorMin = Vector2.zero;
				component.anchorMax = Vector2.one;
				Vector2 vector2 = (component.offsetMin = (component.offsetMax = Vector2.zero));
			}
			Debug.Log("Done");
		}
	}
}
