using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;

namespace Platform.Kernel.ECS.ClientEntitySystem
{
	public class BroadcastHandlerResolver
	{
		protected static HandlerArgumetCombinator combinator = new HandlerArgumetCombinator();

		private readonly BroadcastEventHandlerCollector handlerCollector;

		protected List<Entity> entityAsList = new List<Entity>();

		[Inject]
		public static FlowInstancesCache Cache
		{
			get;
			set;
		}

		public BroadcastHandlerResolver(BroadcastEventHandlerCollector handlerCollector)
		{
			this.handlerCollector = handlerCollector;
		}

		public IList<HandlerInvokeData> Resolve(Event eventInstance, Type handlerType)
		{
			List<HandlerInvokeData> instance = Cache.listHandlersInvokeData.GetInstance();
			IList<HandlerBroadcastInvokeData> handlers = handlerCollector.GetHandlers(handlerType);
			int count = handlers.Count;
			for (int i = 0; i < count; i++)
			{
				HandlerBroadcastInvokeData handlerBroadcastInvokeData = handlers[i];
				if (handlerBroadcastInvokeData.IsActual() || UpdateInvokeData(handlerBroadcastInvokeData, eventInstance))
				{
					instance.Add(handlerBroadcastInvokeData);
				}
			}
			return instance;
		}

		protected bool UpdateInvokeData(HandlerBroadcastInvokeData invokeData, Event eventInstance)
		{
			HandlerInvokeGraph handlerInvokeGraph = invokeData.Handler.HandlerInvokeGraph.Init();
			entityAsList.Clear();
			entityAsList.Add(invokeData.Entity);
			bool flag = combinator.Combine(handlerInvokeGraph, entityAsList);
			if (flag)
			{
				invokeData.Update(eventInstance, handlerInvokeGraph);
			}
			else
			{
				invokeData.UpdateForEmptyCall();
			}
			handlerInvokeGraph.Clear();
			return flag;
		}
	}
}
