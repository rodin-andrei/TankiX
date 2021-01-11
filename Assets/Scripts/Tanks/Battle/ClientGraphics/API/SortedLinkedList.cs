using System;
using System.Collections.Generic;

namespace Tanks.Battle.ClientGraphics.API
{
	public class SortedLinkedList<T> : LinkedList<T> where T : IComparable
	{
		public void AddOrdered(T value)
		{
			for (LinkedListNode<T> linkedListNode = base.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				if (linkedListNode.Value.CompareTo(value) < 0)
				{
					AddBefore(linkedListNode, new LinkedListNode<T>(value));
					return;
				}
			}
			AddLast(new LinkedListNode<T>(value));
		}
	}
}
