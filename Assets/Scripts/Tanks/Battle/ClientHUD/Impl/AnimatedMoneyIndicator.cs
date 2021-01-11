using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientHUD.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	[RequireComponent(typeof(NormalizedAnimatedValue))]
	public class AnimatedMoneyIndicator : AnimatedIndicatorWithFinishComponent<PersonalBattleResultMoneyIndicatorFinishedComponent>
	{
		[SerializeField]
		private UserMoneyIndicatorComponent indicator;

		[SerializeField]
		private Text deltaValue;

		private NormalizedAnimatedValue animation;

		private long Money
		{
			get;
			set;
		}

		private void Awake()
		{
			animation = GetComponent<NormalizedAnimatedValue>();
		}

		private void Update()
		{
			if (Money > 0)
			{
				indicator.Suspend((long)((float)Money * (1f - animation.value)));
				deltaValue.text = "+" + ((long)(animation.value * (float)Money)).ToStringSeparatedByThousands();
				TryToSetAnimationFinished(animation.value, 1f);
			}
			else
			{
				TryToSetAnimationFinished();
			}
		}

		public void Init(Entity screenEntity, long money)
		{
			SetEntity(screenEntity);
			Money = money;
			deltaValue.text = string.Empty;
			GetComponent<Animator>().SetTrigger("Start");
		}
	}
}
