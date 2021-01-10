using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Battle.ClientGraphics.API
{
	public class GraffitiDynamicDecalManager : DynamicDecalManager
	{
		public GraffitiDynamicDecalManager(GameObject root, int maxDecalCount, float decalLifeTimeKoeff, LinkedList<DecalEntry> decalsQueue) : base(default(GameObject), default(int), default(float), default(LinkedList<DecalEntry>))
		{
		}

	}
}
