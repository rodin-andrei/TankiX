using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class DelayedEventManager
	{
		private readonly EngineServiceInternal engineService;

		private LinkedList<PeriodicEventTask> periodicTasks = new LinkedList<PeriodicEventTask>();

		private LinkedList<DelayedEventTask> delayedTasks = new LinkedList<DelayedEventTask>();

		public DelayedEventManager(EngineServiceInternal engine)
		{
			engineService = engine;
		}

		public ScheduleManager SchedulePeriodicEvent(Platform.Kernel.ECS.ClientEntitySystem.API.Event e, ICollection<Entity> entities, float timeInSec)
		{
			PeriodicEventTask periodicEventTask = new PeriodicEventTask(e, engineService, entities, timeInSec);
			periodicTasks.AddLast(periodicEventTask);
			return periodicEventTask;
		}

		public ScheduleManager ScheduleDelayedEvent(Platform.Kernel.ECS.ClientEntitySystem.API.Event e, ICollection<Entity> entities, float timeInSec)
		{
			DelayedEventTask delayedEventTask = new DelayedEventTask(e, entities, engineService, Time.time + timeInSec);
			delayedTasks.AddLast(delayedEventTask);
			return delayedEventTask;
		}

		public void Update(double time)
		{
			UpdatePeriodicTasks(time);
			UpdateDelayedTasks(time);
		}

		private void UpdateDelayedTasks(double time)
		{
			LinkedListNode<DelayedEventTask> linkedListNode = delayedTasks.First;
			while (linkedListNode != null)
			{
				DelayedEventTask value = linkedListNode.Value;
				LinkedListNode<DelayedEventTask> next = linkedListNode.Next;
				if (value.IsCanceled())
				{
					delayedTasks.Remove(value);
				}
				else
				{
					TryUpdate(time, value);
				}
				linkedListNode = next;
			}
		}

		private void TryUpdate(double time, DelayedEventTask task)
		{
			try
			{
				if (task.Update(time))
				{
					delayedTasks.Remove(task);
				}
			}
			catch
			{
				delayedTasks.Remove(task);
				throw;
			}
		}

		private void UpdatePeriodicTasks(double time)
		{
			LinkedListNode<PeriodicEventTask> linkedListNode = periodicTasks.First;
			while (linkedListNode != null)
			{
				PeriodicEventTask value = linkedListNode.Value;
				LinkedListNode<PeriodicEventTask> next = linkedListNode.Next;
				if (value.IsCanceled())
				{
					periodicTasks.Remove(linkedListNode);
				}
				else
				{
					value.Update(time);
				}
				linkedListNode = next;
			}
		}
	}
}
