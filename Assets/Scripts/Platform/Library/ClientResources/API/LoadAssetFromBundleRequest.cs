using System;
using UnityEngine;

namespace Platform.Library.ClientResources.API
{
	public interface LoadAssetFromBundleRequest
	{
		UnityEngine.Object Asset
		{
			get;
		}

		bool IsDone
		{
			get;
		}

		bool IsStarted
		{
			get;
		}

		AssetBundle Bundle
		{
			get;
		}

		string ObjectName
		{
			get;
		}

		Type ObjectType
		{
			get;
		}

		void StartExecute();
	}
}
