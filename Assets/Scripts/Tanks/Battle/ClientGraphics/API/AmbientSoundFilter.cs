namespace Tanks.Battle.ClientGraphics.API
{
	public class AmbientSoundFilter : SingleFadeSoundFilter
	{
		private volatile float filterVolume;

		protected override float FilterVolume
		{
			get
			{
				return filterVolume;
			}
			set
			{
				filterVolume = value;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			FilterVolume = 0f;
		}
	}
}
