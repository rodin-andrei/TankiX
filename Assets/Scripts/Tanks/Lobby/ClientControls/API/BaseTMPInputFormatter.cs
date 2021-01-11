using System.Text;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[RequireComponent(typeof(TMP_InputField))]
	public abstract class BaseTMPInputFormatter : MonoBehaviour
	{
		protected TMP_InputField input;

		private bool formating;

		private void Awake()
		{
			input = GetComponent<TMP_InputField>();
			input.onValueChanged.AddListener(Format);
		}

		protected abstract string FormatAt(char symbol, int charIndex);

		protected abstract string ClearFormat(string text);

		private void Format(string text)
		{
			if (!formating)
			{
				formating = true;
				StringBuilder stringBuilder = new StringBuilder();
				text = ClearFormat(text);
				int num = 0;
				for (int i = 0; i < text.Length; i++)
				{
					string text2 = FormatAt(text[i], i);
					stringBuilder.Append(text2);
					num += text2.Length - 1;
				}
				input.text = stringBuilder.ToString();
				input.stringPosition += num;
				input.text = stringBuilder.ToString();
				formating = false;
			}
		}
	}
}
