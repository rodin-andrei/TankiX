using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;

namespace Platform.Library.ClientResources.API
{
	[Serializable]
	public class AssetReference
	{
		public static readonly string GUID_FIELD_SERIALIZED_NAME = "assetGuid";

		[SerializeField]
		private string assetGuid;

		[SerializeField]
		private UnityEngine.Object embededReference;

		private UnityEngine.Object hardReference;

		public Action<UnityEngine.Object> OnLoaded;

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		public bool IsDefined
		{
			get
			{
				return !string.IsNullOrEmpty(assetGuid);
			}
		}

		public string AssetGuid
		{
			get
			{
				return assetGuid;
			}
			set
			{
				if (assetGuid != value)
				{
					assetGuid = value;
					hardReference = null;
					embededReference = null;
				}
			}
		}

		public UnityEngine.Object Reference
		{
			get
			{
				return (!(embededReference != null)) ? hardReference : embededReference;
			}
		}

		public AssetReference()
		{
		}

		public AssetReference(string assetGuid)
			: this()
		{
			this.assetGuid = assetGuid;
		}

		public void SetReference(UnityEngine.Object reference)
		{
			hardReference = reference;
			if (OnLoaded != null)
			{
				OnLoaded(reference);
			}
		}

		public void Load()
		{
			Load(0);
		}

		public void Load(int priority)
		{
			Entity entity = EngineService.Engine.CreateEntity("Load " + assetGuid);
			entity.AddComponent(new AssetReferenceComponent(this));
			entity.AddComponent(new AssetRequestComponent(priority));
		}

		public override bool Equals(object obj)
		{
			return assetGuid == ((AssetReference)obj).assetGuid;
		}

		public override int GetHashCode()
		{
			return assetGuid.GetHashCode();
		}

		public override string ToString()
		{
			return "AssetReference [assetGuid=" + assetGuid + "]";
		}
	}
}
