using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class MatchMakingModeRestrictionsComponent : Component
	{
		private int _minimalRank;

		private int _maximalRank = int.MaxValue;

		private int _minimalShowRank;

		private int _maximalShowRank = int.MaxValue;

		public int MinimalRank
		{
			get
			{
				return _minimalRank;
			}
			set
			{
				_minimalRank = value;
			}
		}

		public int MaximalRank
		{
			get
			{
				return _maximalRank;
			}
			set
			{
				_maximalRank = value;
			}
		}

		public int MinimalShowRank
		{
			get
			{
				return _minimalShowRank;
			}
			set
			{
				_minimalShowRank = value;
			}
		}

		public int MaximalShowRank
		{
			get
			{
				return _maximalShowRank;
			}
			set
			{
				_maximalShowRank = value;
			}
		}
	}
}
