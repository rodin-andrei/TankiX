using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
	public class CurvedUIEnabler : MonoBehaviour
	{
		public void RefreshCurve()
		{
			Graphic[] componentsInChildren = GetComponentsInChildren<Graphic>(true);
			foreach (Graphic graphic in componentsInChildren)
			{
				if (graphic.GetComponent<CurvedUIVertexEffect>() == null)
				{
					graphic.gameObject.AddComponent<CurvedUIVertexEffect>();
					graphic.SetAllDirty();
				}
			}
			InputField[] componentsInChildren2 = GetComponentsInChildren<InputField>(true);
			foreach (InputField inputField in componentsInChildren2)
			{
				if (inputField.GetComponent<CurvedUIInputFieldCaret>() == null)
				{
					inputField.gameObject.AddComponent<CurvedUIInputFieldCaret>();
				}
			}
			TextMeshProUGUI[] componentsInChildren3 = GetComponentsInChildren<TextMeshProUGUI>(true);
			foreach (TextMeshProUGUI textMeshProUGUI in componentsInChildren3)
			{
				if (textMeshProUGUI.GetComponent<CurvedUITMP>() == null)
				{
					textMeshProUGUI.gameObject.AddComponent<CurvedUITMP>();
					textMeshProUGUI.SetAllDirty();
				}
			}
		}
	}
}
