using System;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageSelectorUI : MonoBehaviour
	{
		[SerializeField]
		private GameObject hullButton;

		[SerializeField]
		private GameObject turretButton;

		[SerializeField]
		private GameObject modulesButton;

		[SerializeField]
		private GameObject visualButton;

		[SerializeField]
		private Animator hullAnimator;

		[SerializeField]
		private Animator turretAnimator;

		public Action onTurretSelected;

		public Action onHullSelected;

		private Action onEnable;

		public void SelectVisual()
		{
			SetSelectionButton(visualButton);
		}

		public void SelectModules()
		{
			SetSelectionButton(modulesButton);
		}

		private void Awake()
		{
			hullButton.GetComponent<Button>().onClick.AddListener(OnHullSelected);
			turretButton.GetComponent<Button>().onClick.AddListener(OnSelectTurret);
		}

		public void SelectHull()
		{
			SetSelectionButton(hullButton);
			if (!base.gameObject.activeInHierarchy)
			{
				onEnable = delegate
				{
				};
			}
		}

		private void OnSelectTurret()
		{
			SelectTurret();
			onTurretSelected();
		}

		private void OnHullSelected()
		{
			SelectHull();
			onHullSelected();
		}

		public void SelectTurret()
		{
			SetSelectionButton(turretButton);
			if (!base.gameObject.activeInHierarchy)
			{
				onEnable = delegate
				{
				};
			}
		}

		private void SetSelectionButton(GameObject button)
		{
			button.GetComponent<RadioButton>().Activate();
		}

		private void OnEnable()
		{
			if (onEnable != null)
			{
				onEnable();
			}
		}
	}
}
