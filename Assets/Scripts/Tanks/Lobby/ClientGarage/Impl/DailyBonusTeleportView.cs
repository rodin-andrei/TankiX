using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class DailyBonusTeleportView : MonoBehaviour
	{
		public List<Image> teleports;
		public GameObject yelloCrystal;
		public GameObject brokenCrystal;
		public GameObject crystalOutline;
		public Button getNewTeleportButton;
		public Image fill;
		public GameObject upgradeTeleportView;
		public InactiveTeleportView inactiveTeleportView;
		public ActiveTeleportView activeTeleportView;
		public DetailTargetTeleportView detailTargetTeleportView;
		public GameObject brokenTeleport;
		public List<Image> lines;
		public Color activeColor;
	}
}
