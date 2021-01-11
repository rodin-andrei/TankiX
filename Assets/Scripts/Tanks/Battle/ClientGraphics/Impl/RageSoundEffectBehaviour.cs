namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RageSoundEffectBehaviour : LimitedInstancingSoundEffectBehaviour
	{
		private const int REGISTER_INDEX = 1;

		private const float MIN_TIME_FOR_PLAYING_SEC = 0.5f;

		public static void CreateRageSound(RageSoundEffectBehaviour effectPrefab)
		{
			LimitedInstancingSoundEffectBehaviour.CreateSoundEffectInstance(effectPrefab, 1, 0.5f);
		}
	}
}
