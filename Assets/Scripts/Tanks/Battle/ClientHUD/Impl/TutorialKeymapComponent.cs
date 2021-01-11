using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class TutorialKeymapComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject prefab;

		public float showDelay = 30f;

		public float destroyDelay = 0.333333343f;

		private GameObject content;

		private float showTime = float.MaxValue;

		private float hideTime = float.MaxValue;

		private bool visible;

		public bool Visible
		{
			get
			{
				return content != null && visible;
			}
			set
			{
				if (value)
				{
					if (content != null)
					{
						Object.Destroy(content);
					}
					content = Object.Instantiate(prefab, base.transform, false);
				}
				if (content != null)
				{
					content.GetComponent<Animator>().SetTrigger((!value) ? "HIDE" : "SHOW");
				}
				if (value)
				{
					showTime = Time.time;
				}
				else
				{
					hideTime = Time.time;
				}
				visible = value;
			}
		}

		public void ResetState()
		{
			showTime = float.MaxValue;
			hideTime = float.MaxValue;
			visible = false;
			if (content != null)
			{
				Object.Destroy(content);
				content = null;
			}
		}

		private void Update()
		{
			if (Visible && Time.time > showTime + showDelay)
			{
				Visible = false;
			}
			if (!visible && Time.time > hideTime + destroyDelay && content != null)
			{
				Object.Destroy(content);
				content = null;
			}
		}
	}
}
