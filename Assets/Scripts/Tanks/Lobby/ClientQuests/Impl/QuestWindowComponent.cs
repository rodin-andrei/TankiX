using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class QuestWindowComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject questPrefab;

		[SerializeField]
		private GameObject questCellPrefab;

		[SerializeField]
		private GameObject questsContainer;

		[SerializeField]
		private GameObject background;

		private List<Animator> animators;

		public Action HideDelegate;

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		public GameObject QuestPrefab
		{
			get
			{
				return questPrefab;
			}
		}

		public GameObject QuestCellPrefab
		{
			get
			{
				return questCellPrefab;
			}
		}

		public GameObject QuestsContainer
		{
			get
			{
				return questsContainer;
			}
		}

		public bool ShowOnMainScreen
		{
			get;
			set;
		}

		public bool ShowProgress
		{
			get;
			set;
		}

		public void Show(List<Animator> animators)
		{
			base.gameObject.SetActive(true);
			background.SetActive(true);
			if (!ShowOnMainScreen)
			{
				return;
			}
			MainScreenComponent.Instance.OverrideOnBack(Hide);
			this.animators = animators;
			foreach (Animator animator in animators)
			{
				animator.SetBool("Visible", false);
			}
		}

		public void HideWindow()
		{
			Hide();
		}

		private void Hide()
		{
			if (HideDelegate != null)
			{
				HideDelegate();
				HideDelegate = null;
			}
			else if (ShowOnMainScreen)
			{
				MainScreenComponent.Instance.ClearOnBackOverride();
				ShowHiddenScreenParts();
			}
			base.gameObject.SetActive(false);
		}

		private void ShowHiddenScreenParts()
		{
			if (animators == null)
			{
				return;
			}
			foreach (Animator animator in animators)
			{
				animator.SetBool("Visible", true);
			}
			animators = null;
		}

		private new void OnDisable()
		{
			ShowHiddenScreenParts();
		}

		private void Update()
		{
			if (InputMapping.Cancel && ShowOnMainScreen)
			{
				Hide();
			}
		}
	}
}
