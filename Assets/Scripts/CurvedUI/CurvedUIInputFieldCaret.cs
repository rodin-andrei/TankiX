using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
	public class CurvedUIInputFieldCaret : MonoBehaviour
	{
		private InputField myField;

		private RectTransform myCaret;

		private Color origCaretColor;

		private Color origSelectionColor;

		private bool selectingText;

		private int lastCharDist = 2;

		private float blinkTimer;

		private bool selected
		{
			get
			{
				return myField != null && myField.isFocused;
			}
		}

		public Color CaretColor
		{
			get
			{
				return origCaretColor;
			}
			set
			{
				origCaretColor = value;
			}
		}

		public Color SelectionColor
		{
			get
			{
				return origSelectionColor;
			}
			set
			{
				origSelectionColor = value;
			}
		}

		public float CaretBlinkRate
		{
			get
			{
				return myField.caretBlinkRate;
			}
			set
			{
				myField.caretBlinkRate = value;
			}
		}

		private void Awake()
		{
			myField = GetComponent<InputField>();
		}

		private void Update()
		{
			if (selected)
			{
				UpdateCaret();
			}
		}

		private void CreateCaret()
		{
			GameObject gameObject = new GameObject("CurvedUICaret");
			gameObject.AddComponent<RectTransform>();
			gameObject.AddComponent<Image>();
			gameObject.AddComponent<CurvedUIVertexEffect>();
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.localScale = Vector3.one;
			(gameObject.transform as RectTransform).anchoredPosition3D = Vector3.zero;
			(gameObject.transform as RectTransform).pivot = new Vector2(0f, 1f);
			gameObject.GetComponent<Image>().color = myField.caretColor;
			myCaret = gameObject.transform as RectTransform;
			gameObject.transform.SetAsFirstSibling();
			myField.customCaretColor = true;
			origCaretColor = myField.caretColor;
			myField.caretColor = new Color(0f, 0f, 0f, 0f);
			origSelectionColor = myField.selectionColor;
			myField.selectionColor = new Color(0f, 0f, 0f, 0f);
			gameObject.gameObject.SetActive(false);
		}

		private void UpdateCaret()
		{
			if (myCaret == null)
			{
				CreateCaret();
			}
			Vector2 localPositionInText = GetLocalPositionInText(myField.caretPosition);
			if (myField.selectionFocusPosition != myField.selectionAnchorPosition)
			{
				selectingText = true;
				Vector2 vector = new Vector2(GetLocalPositionInText(myField.selectionAnchorPosition).x - GetLocalPositionInText(myField.selectionFocusPosition).x, GetLocalPositionInText(myField.selectionAnchorPosition).y - GetLocalPositionInText(myField.selectionFocusPosition).y);
				localPositionInText = ((!(vector.x < 0f)) ? GetLocalPositionInText(myField.selectionFocusPosition) : GetLocalPositionInText(myField.selectionAnchorPosition));
				vector = new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y) + (float)myField.textComponent.fontSize);
				myCaret.sizeDelta = new Vector2(vector.x, vector.y);
				myCaret.anchoredPosition = localPositionInText;
				myCaret.GetComponent<Image>().color = origSelectionColor;
			}
			else
			{
				selectingText = false;
				myCaret.sizeDelta = new Vector2(myField.caretWidth, myField.textComponent.fontSize);
				myCaret.anchoredPosition = localPositionInText;
				myCaret.GetComponent<Image>().color = origCaretColor;
			}
			BlinkCaret();
		}

		private void BlinkCaret()
		{
			blinkTimer += Time.deltaTime;
			if (blinkTimer >= myField.caretBlinkRate)
			{
				blinkTimer = 0f;
				myCaret.gameObject.SetActive(selectingText || !myCaret.gameObject.activeSelf);
			}
		}

		private Vector2 GetLocalPositionInText(int charNo)
		{
			if (myField.isFocused)
			{
				TextGenerator cachedTextGenerator = myField.textComponent.cachedTextGenerator;
				if (charNo > cachedTextGenerator.characterCount - 1)
				{
					charNo = cachedTextGenerator.characterCount - 1;
				}
				if (charNo > 0)
				{
					UICharInfo uICharInfo = cachedTextGenerator.characters[charNo - 1];
					float x = (uICharInfo.cursorPos.x + uICharInfo.charWidth) / myField.textComponent.pixelsPerUnit + (float)lastCharDist;
					float y = uICharInfo.cursorPos.y / myField.textComponent.pixelsPerUnit;
					return new Vector2(x, y);
				}
				UICharInfo uICharInfo2 = cachedTextGenerator.characters[charNo];
				float x2 = uICharInfo2.cursorPos.x / myField.textComponent.pixelsPerUnit;
				float y2 = uICharInfo2.cursorPos.y / myField.textComponent.pixelsPerUnit;
				return new Vector2(x2, y2);
			}
			return Vector2.zero;
		}
	}
}
