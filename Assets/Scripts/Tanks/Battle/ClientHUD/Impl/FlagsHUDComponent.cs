using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class FlagsHUDComponent : BehaviourComponent, AttachToEntityListener
	{
		[SerializeField]
		private FlagController blueFlag;

		[SerializeField]
		private RectTransform blueFlagTransform;

		[SerializeField]
		private FlagController redFlag;

		[SerializeField]
		private RectTransform redFlagTransform;

		private int showRequests;

		public FlagController BlueFlag
		{
			get
			{
				return blueFlag;
			}
		}

		public FlagController RedFlag
		{
			get
			{
				return redFlag;
			}
		}

		public float RedFlagNormalizedPosition
		{
			set
			{
				if (value > 0.5f && blueFlagTransform.anchorMax.x < 0.5f)
				{
					redFlagTransform.SetAsLastSibling();
				}
				SetFlagPosition(redFlagTransform, 1f - Mathf.Clamp01(value));
			}
		}

		public float BlueFlagNormalizedPosition
		{
			set
			{
				if (value > 0.5f && redFlagTransform.anchorMax.x > 0.5f)
				{
					blueFlagTransform.SetAsLastSibling();
				}
				SetFlagPosition(blueFlagTransform, Mathf.Clamp01(value));
			}
		}

		public void RequestShow()
		{
		}

		public void RequestHide()
		{
		}

		private void SetFlagPosition(RectTransform flag, float position)
		{
			Vector2 vector3 = (flag.anchorMax = (flag.anchorMin = new Vector2(position, 0f)));
			flag.anchoredPosition = new Vector2(0f, (position != 0f && position != 1f) ? (-8.5f) : 0f);
		}

		private void OnEnable()
		{
		}

		public void AttachedToEntity(Entity entity)
		{
			showRequests = 0;
		}
	}
}
