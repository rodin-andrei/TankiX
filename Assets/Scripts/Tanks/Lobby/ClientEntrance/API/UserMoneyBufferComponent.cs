using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientEntrance.API
{
	public class UserMoneyBufferComponent : Component
	{
		private int crystalBuffer;

		private int xCrystalBuffer;

		public int CrystalBuffer
		{
			get
			{
				return crystalBuffer;
			}
			set
			{
				crystalBuffer = value;
			}
		}

		public int XCrystalBuffer
		{
			get
			{
				return xCrystalBuffer;
			}
			set
			{
				xCrystalBuffer = value;
			}
		}

		public void ChangeCrystalBufferBy(int delta)
		{
			crystalBuffer += delta;
		}

		public void ChangeXCrystalBufferBy(int delta)
		{
			xCrystalBuffer += delta;
		}
	}
}
