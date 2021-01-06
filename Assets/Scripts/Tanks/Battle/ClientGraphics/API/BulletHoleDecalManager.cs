using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Battle.ClientGraphics.API
{
	public class BulletHoleDecalManager : DynamicDecalManager
	{
		public BulletHoleDecalManager(GameObject root, int maxDecalCount, float decalLifeTimeKoeff, LinkedList<DecalEntry> decalsQueue) : base(default(GameObject), default(int), default(float), default(LinkedList<DecalEntry>))
		{
		}

	}
}
