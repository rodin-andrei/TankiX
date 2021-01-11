using UnityEngine;

namespace Tanks.ClientLauncher.API
{
	public class VersionBehaviour : MonoBehaviour
	{
		[SerializeField]
		private string currentVersion;

		[SerializeField]
		private string distributionUrl;

		public string CurrentVersion
		{
			get
			{
				return currentVersion;
			}
			set
			{
				currentVersion = value;
			}
		}

		public string DistributionUrl
		{
			get
			{
				return distributionUrl;
			}
			set
			{
				distributionUrl = value;
			}
		}
	}
}
