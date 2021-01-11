namespace Tanks.Battle.ClientGraphics.Impl
{
	public class KillTankSoundEffectBehaviour : LimitedInstancingSoundEffectBehaviour
	{
		private const int REGISTER_INDEX = 0;

		private const float MIN_TIME_FOR_PLAYING_SEC = 0.5f;

		public static bool CreateKillTankSound(KillTankSoundEffectBehaviour effectPrefab)
		{
			return LimitedInstancingSoundEffectBehaviour.CreateSoundEffectInstance(effectPrefab, 0, 0.5f);
		}
	}
}
