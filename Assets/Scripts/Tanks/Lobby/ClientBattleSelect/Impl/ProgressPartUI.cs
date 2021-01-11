using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class ProgressPartUI : MonoBehaviour
	{
		[SerializeField]
		private ExperienceResultUI experienceResult;

		[SerializeField]
		private EquipmentResultUI turretResult;

		[SerializeField]
		private EquipmentResultUI hullResult;

		[SerializeField]
		private GameObject progressResult;

		[SerializeField]
		private GameObject energyResult;

		[SerializeField]
		private GameObject leagueResult;

		[SerializeField]
		private GameObject containerResult;

		private void OnDisable()
		{
			progressResult.SetActive(false);
			energyResult.SetActive(false);
			leagueResult.SetActive(false);
			containerResult.SetActive(false);
			progressResult.GetComponent<CanvasGroup>().alpha = 0f;
			energyResult.GetComponent<CanvasGroup>().alpha = 0f;
			leagueResult.GetComponent<CanvasGroup>().alpha = 0f;
			containerResult.GetComponent<CanvasGroup>().alpha = 0f;
		}

		public void SetExperienceResult(float expReward, int[] levels, BattleResultsTextTemplatesComponent textTemplates)
		{
			experienceResult.SetProgress(expReward, levels, textTemplates);
		}

		public void SetTurretResult(Entity turret, float expReward, int previousUpgradeLevel, int[] levels, BattleResultsTextTemplatesComponent textTemplates)
		{
			turretResult.SetProgress(turret, expReward, previousUpgradeLevel, levels, textTemplates);
		}

		public void SetHullResult(Entity hull, float expReward, int previousUpgradeLevel, int[] levels, BattleResultsTextTemplatesComponent textTemplates)
		{
			hullResult.SetProgress(hull, expReward, previousUpgradeLevel, levels, textTemplates);
		}

		public void ShowExperienceResult()
		{
			experienceResult.SetNewProgress();
			turretResult.SetNewProgress();
			hullResult.SetNewProgress();
		}
	}
}
