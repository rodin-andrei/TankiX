using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	[RequireComponent(typeof(Text))]
	[RequireComponent(typeof(NormalizedAnimatedValue))]
	public class CooldownAnimation : MonoBehaviour
	{
		private Text _text;

		private NormalizedAnimatedValue _animatedValue;

		private float cooldown;

		private Text text
		{
			get
			{
				if (_text == null)
				{
					_text = GetComponent<Text>();
				}
				return _text;
			}
		}

		private NormalizedAnimatedValue animatedValue
		{
			get
			{
				if (_animatedValue == null)
				{
					_animatedValue = GetComponent<NormalizedAnimatedValue>();
				}
				return _animatedValue;
			}
		}

		public float Cooldown
		{
			get
			{
				return cooldown;
			}
			set
			{
				cooldown = value;
				text.text = string.Format("{0:0}", value);
			}
		}

		private void Awake()
		{
			text.text = string.Empty;
		}

		private void OnDisable()
		{
			text.text = string.Empty;
		}

		private void Update()
		{
			float num = animatedValue.value * cooldown;
			if (!(num <= 0f))
			{
				text.text = string.Format("{0:0}", num);
			}
		}
	}
}
