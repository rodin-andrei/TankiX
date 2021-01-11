using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(Animator))]
	public class GameModeSelectButtonComponent : BehaviourComponent, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		[SerializeField]
		private TextMeshProUGUI modeTitle;

		[SerializeField]
		private TextMeshProUGUI modeDescription;

		[SerializeField]
		private GameObject blockLayer;

		[SerializeField]
		private GameObject restriction;

		[SerializeField]
		private ImageSkin modeImage;

		[SerializeField]
		private Material grayscaleMaterial;

		[SerializeField]
		private GameObject notAvailableForNotSquadLeaderLabel;

		[SerializeField]
		private GameObject notAvailableInSquadLabel;

		private bool pointerInside;

		public string GameModeTitle
		{
			get
			{
				return modeTitle.text;
			}
			set
			{
				modeTitle.text = value;
			}
		}

		public string ModeDescription
		{
			get
			{
				return modeDescription.text;
			}
			set
			{
				modeDescription.text = value;
			}
		}

		public bool Restricted
		{
			get;
			private set;
		}

		public void SetRestricted(bool restricted)
		{
			Restricted = restricted;
			restriction.gameObject.SetActive(restricted);
			blockLayer.gameObject.SetActive(restricted);
			CheckForTutorialEvent checkForTutorialEvent = new CheckForTutorialEvent();
			ScheduleEvent(checkForTutorialEvent, new EntityStub());
			SetAvailableForSquadMode(false);
			if (!restricted && checkForTutorialEvent.TutorialIsActive)
			{
				GetComponent<Button>().interactable = false;
			}
			else
			{
				GetComponent<Button>().interactable = !restricted;
			}
		}

		private void OnEnable()
		{
			SetAvailableForSquadMode(false);
		}

		public void SetAvailableForSquadMode(bool userInSquadNow, bool userIsSquadLeader = false, bool modeIsDefault = false)
		{
			notAvailableInSquadLabel.gameObject.SetActive(false);
			notAvailableForNotSquadLeaderLabel.gameObject.SetActive(false);
			if (!Restricted && userInSquadNow)
			{
				if (userIsSquadLeader && modeIsDefault)
				{
					notAvailableInSquadLabel.gameObject.SetActive(true);
				}
				else if (!userIsSquadLeader)
				{
					notAvailableForNotSquadLeaderLabel.gameObject.SetActive(true);
				}
			}
		}

		public void SetInactive()
		{
			Restricted = true;
			SetAvailableForSquadMode(true);
			blockLayer.gameObject.SetActive(true);
			GetComponent<Button>().interactable = false;
			modeImage.gameObject.GetComponent<Image>().material = grayscaleMaterial;
		}

		public void SetImage(string spriteUid)
		{
			modeImage.SpriteUid = spriteUid;
			modeImage.enabled = true;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			pointerInside = true;
			if (!TutorialCanvas.Instance.IsShow || GetComponent<Button>().interactable)
			{
				GetComponent<Animator>().SetTrigger("ShowDescription");
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			pointerInside = false;
			if (!TutorialCanvas.Instance.IsShow || GetComponent<Button>().interactable)
			{
				GetComponent<Animator>().SetTrigger("HideDescription");
			}
		}
	}
}
