using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.API
{
	public class DecalManagerComponent : Component
	{
		private LinkedList<DecalEntry> decalsQueue = new LinkedList<DecalEntry>();

		private DecalMeshBuilder _decalMeshBuilder;

		private BulletHoleDecalManager bulletHoleDecalManager;

		private GraffitiDynamicDecalManager graffitiDynamicDecalManager;

		private bool enableDecals;

		public LinkedList<DecalEntry> DecalsQueue
		{
			get
			{
				return decalsQueue;
			}
		}

		public BulletHoleDecalManager BulletHoleDecalManager
		{
			get
			{
				return bulletHoleDecalManager;
			}
			set
			{
				bulletHoleDecalManager = value;
			}
		}

		public GraffitiDynamicDecalManager GraffitiDynamicDecalManager
		{
			get
			{
				return graffitiDynamicDecalManager;
			}
			set
			{
				graffitiDynamicDecalManager = value;
			}
		}

		public DecalMeshBuilder DecalMeshBuilder
		{
			get
			{
				return _decalMeshBuilder;
			}
			set
			{
				_decalMeshBuilder = value;
			}
		}

		public bool EnableDecals
		{
			get
			{
				return enableDecals;
			}
			set
			{
				enableDecals = value;
			}
		}
	}
}
