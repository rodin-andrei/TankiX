using System.Collections.Generic;
using Tanks.Battle.ClientBattleSelect.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MVPOtherStatComponent : MonoBehaviour
	{
		private delegate int UserField(UserResult user);

		[SerializeField]
		private MVPStatElementComponent flagsDelivered;

		[SerializeField]
		private MVPStatElementComponent flagsReturned;

		[SerializeField]
		private MVPStatElementComponent damage;

		[SerializeField]
		private MVPStatElementComponent killStreak;

		[SerializeField]
		private MVPStatElementComponent bonuseTaken;

		private UserResult mvp;

		private List<UserResult> allUsers;

		private int showedItems;

		private static int MAX_SHOWED_ITEM = 4;

		public void Set(UserResult mvp, BattleResultForClient battleResults)
		{
			this.mvp = mvp;
			allUsers = new List<UserResult>();
			allUsers.AddRange(battleResults.DmUsers);
			allUsers.AddRange(battleResults.RedUsers);
			allUsers.AddRange(battleResults.BlueUsers);
			showedItems = 0;
			SetStatItem(flagsDelivered, mvp, allUsers, (UserResult x) => x.Flags);
			SetStatItem(flagsReturned, mvp, allUsers, (UserResult x) => x.FlagReturns);
			SetStatItem(damage, mvp, allUsers, (UserResult x) => x.Damage);
			SetStatItem(killStreak, mvp, allUsers, (UserResult x) => x.KillStrike);
			SetStatItem(bonuseTaken, mvp, allUsers, (UserResult x) => x.BonusesTaken);
		}

		private void SetStatItem(MVPStatElementComponent item, UserResult mvp, List<UserResult> allUsers, UserField field)
		{
			if (showedItems < MAX_SHOWED_ITEM)
			{
				item.Count = field(mvp);
				item.SetBest(isBest(mvp, allUsers, field));
				if (item.ShowIfCan())
				{
					showedItems++;
				}
			}
			else
			{
				item.Hide();
			}
		}

		private bool isBest(UserResult mvp, List<UserResult> allUsers, UserField field)
		{
			allUsers.Sort((UserResult x, UserResult y) => field(y) - field(x));
			return field(allUsers[0]) == field(mvp) && field(mvp) > 0;
		}
	}
}
