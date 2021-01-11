using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModulePropertyView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI propertyName;

		[SerializeField]
		private TextMeshProUGUI currentParam;

		[SerializeField]
		private TextMeshProUGUI nextParam;

		[SerializeField]
		private ImageSkin icon;

		[SerializeField]
		private GameObject Progress;

		[SerializeField]
		private Image currentProgress;

		[SerializeField]
		private Image nextProgress;

		private float current;

		private float next;

		private string units;

		private string format;

		public GameObject FillNext;

		public GameObject NextString;

		public float CurentProgressBar
		{
			set
			{
				current = value;
			}
		}

		public float nextProgressBar
		{
			set
			{
				next = value;
			}
		}

		public string Units
		{
			set
			{
				units = value;
			}
		}

		public string PropertyName
		{
			set
			{
				propertyName.text = value;
			}
		}

		public string Format
		{
			get
			{
				return format ?? "{0:0}";
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					format = "{0:0}";
				}
				else
				{
					format = "{0:" + value + "}";
				}
			}
		}

		public string CurrentParamString
		{
			set
			{
				currentParam.text = string.Format(Format, value);
			}
		}

		public string NextParamString
		{
			set
			{
				nextParam.text = string.Format(Format, value);
			}
		}

		public float CurrentParam
		{
			set
			{
				currentParam.text = string.Format(Format, value) + " " + units;
				current = value;
			}
		}

		public float NextParam
		{
			set
			{
				nextParam.text = string.Format(Format, value) + " " + units;
				if (nextParam.text == currentParam.text)
				{
					nextParam.text = string.Format(Format, " ");
				}
				next = value;
			}
		}

		public bool ProgressBar
		{
			set
			{
				Progress.SetActive(value);
			}
		}

		public string SpriteUid
		{
			set
			{
				icon.SpriteUid = value;
			}
		}

		public float MaxParam
		{
			set
			{
				currentProgress.fillAmount = current / value;
				nextProgress.fillAmount = next / value;
			}
		}
	}
}
