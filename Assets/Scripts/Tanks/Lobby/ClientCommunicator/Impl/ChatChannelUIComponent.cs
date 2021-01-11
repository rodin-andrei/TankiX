using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatChannelUIComponent : BehaviourComponent, AttachToEntityListener
	{
		private Entity entity;

		[SerializeField]
		private GameObject tab;

		[SerializeField]
		private Color selectedColor;

		[SerializeField]
		private Color unselectedColor;

		[SerializeField]
		private Image back;

		[SerializeField]
		private ImageSkin icon;

		[SerializeField]
		private new TMP_Text name;

		[SerializeField]
		private GameObject badge;

		[SerializeField]
		private TMP_Text counterText;

		private int counter;

		public GameObject Tab
		{
			get
			{
				return tab;
			}
			set
			{
				tab = value;
			}
		}

		public string Name
		{
			get
			{
				return name.text;
			}
			set
			{
				name.text = value;
			}
		}

		public int Unread
		{
			get
			{
				return counter;
			}
			set
			{
				counter = value;
				badge.SetActive(counter > 0);
				counterText.text = counter.ToString();
			}
		}

		public void SetIcon(string spriteUid)
		{
			icon.SpriteUid = spriteUid;
		}

		public string GetSpriteUid()
		{
			return icon.SpriteUid;
		}

		public void Select()
		{
			back.color = selectedColor;
		}

		public void Deselect()
		{
			back.color = unselectedColor;
		}

		public void OnClick()
		{
			if (entity != null)
			{
				ECSBehaviour.EngineService.Engine.ScheduleEvent(new SelectChannelEvent(), entity);
			}
		}

		public void AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}
	}
}
