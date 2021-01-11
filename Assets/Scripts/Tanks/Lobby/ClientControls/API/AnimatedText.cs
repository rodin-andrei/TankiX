using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class AnimatedText : MonoBehaviour
	{
		[SerializeField]
		protected TextMeshProUGUI message;

		private bool textAnimation = true;

		private string resultText;

		private int currentCharIndex;

		[SerializeField]
		private float textAnimationDelay = 0.01f;

		private float timer;

		public bool TextAnimation
		{
			get
			{
				return textAnimation;
			}
		}

		public string ResultText
		{
			get
			{
				return resultText;
			}
			set
			{
				message.text = string.Empty;
				resultText = value;
			}
		}

		public int CurrentCharIndex
		{
			get
			{
				return currentCharIndex;
			}
			set
			{
				currentCharIndex = value;
				if (currentCharIndex < resultText.Length)
				{
					string empty = string.Empty;
					char c = resultText[currentCharIndex];
					empty += c;
					if (c == '<')
					{
						while (c != '>' && currentCharIndex < resultText.Length - 1)
						{
							currentCharIndex++;
							c = resultText[currentCharIndex];
							empty += c;
						}
					}
					message.text += empty;
				}
				else
				{
					message.text = resultText;
					textAnimation = false;
				}
			}
		}

		private void Reset()
		{
			message = GetComponent<TextMeshProUGUI>();
		}

		private void Update()
		{
			UpdateTextAnimation();
		}

		private void UpdateTextAnimation()
		{
			if (textAnimation)
			{
				timer += Time.deltaTime;
				if (timer > textAnimationDelay)
				{
					timer = 0f;
					CurrentCharIndex++;
				}
			}
		}

		public void Animate()
		{
			textAnimation = true;
			CurrentCharIndex = 0;
		}

		public void ForceComplete()
		{
			CurrentCharIndex = resultText.Length;
		}
	}
}
