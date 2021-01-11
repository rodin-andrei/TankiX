using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientNotifications.Impl
{
	public class AnimatedValueComponent : BehaviourComponent
	{
		public float animationTime;

		public AnimationCurve curve;

		[SerializeField]
		private long startValue;

		[SerializeField]
		private long maximum;

		[SerializeField]
		private long price;

		[SerializeField]
		private Slider upgradeSlider;

		[SerializeField]
		private TextMeshProUGUI upgradeCount;

		[SerializeField]
		private GameObject outline;

		private float time;

		private bool isOutline;

		[SerializeField]
		private bool canStart;

		private bool isStart;

		private bool canUpdate;

		private float startTime;

		public long StartValue
		{
			set
			{
				startValue = value;
			}
		}

		public long Maximum
		{
			set
			{
				maximum = value;
			}
		}

		public long Price
		{
			set
			{
				price = value;
			}
		}

		private void Update()
		{
			if (canStart)
			{
				startTime = Time.time;
				canUpdate = true;
				canStart = false;
				isStart = true;
			}
			if (canUpdate && price > 0)
			{
				time = Time.time - startTime;
				float num = curve.Evaluate(time / animationTime) * (float)(maximum - startValue);
				float num2 = curve.Evaluate(time / animationTime) * (float)(maximum - startValue) * 100f;
				long num3 = (long)((float)startValue + num);
				long num4 = (long)((float)(startValue * 100) + num2);
				upgradeSlider.value = num4;
				upgradeCount.text = string.Empty + num3 + "/" + price;
				if (num3 >= price && outline != null)
				{
					outline.GetComponent<Animator>().SetTrigger("Blink");
				}
			}
			if (canUpdate && startValue >= price && outline != null && price > 0)
			{
				outline.GetComponent<Animator>().SetTrigger("Upgrade");
			}
			if (time >= animationTime)
			{
				canUpdate = false;
			}
			if (price == 0)
			{
				upgradeCount.text = string.Empty;
			}
		}
	}
}
