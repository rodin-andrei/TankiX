using System.Collections.Generic;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.System.Data.Exchange.ClientNetwork.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class LoadUsersSystem : ECSSystem
	{
		public class UsersLoadedInternalEvent : Event
		{
		}

		[OnEventFire]
		public void AddStorage(NodeAddedEvent e, SingleNode<SelfUserComponent> selfUser)
		{
			selfUser.Entity.AddComponent<SharedUsersStorageComponent>();
		}

		[OnEventFire]
		public void LoadUser(NodeAddedEvent e, SingleNode<LoadUserComponent> loadUser, [JoinAll] SingleNode<SharedUsersStorageComponent> storage, [JoinByUser] SingleNode<ClientSessionComponent> session)
		{
			if (storage.component.UserId2EntityIdMap.ContainsKey(loadUser.component.UserId))
			{
				ScheduleEvent<UsersLoadedInternalEvent>(loadUser);
			}
			else
			{
				LoadUsersEvent eventInstance = new LoadUsersEvent(loadUser.Entity.Id, loadUser.component.UserId);
				ScheduleEvent(eventInstance, session);
			}
			storage.component.UserId2EntityIdMap.Add(loadUser.component.UserId, loadUser.Entity.Id);
		}

		[OnEventFire]
		public void LoadUsers(NodeAddedEvent e, SingleNode<LoadUsersComponent> loadUsers, [JoinAll] SingleNode<SharedUsersStorageComponent> storage, [JoinByUser] SingleNode<ClientSessionComponent> session)
		{
			HashSet<long> hashSet = new HashSet<long>();
			foreach (long userId in loadUsers.component.UserIds)
			{
				if (!storage.component.UserId2EntityIdMap.ContainsKey(userId))
				{
					hashSet.Add(userId);
				}
				storage.component.UserId2EntityIdMap.Add(userId, loadUsers.Entity.Id);
			}
			if (hashSet.Count > 0)
			{
				LoadUsersEvent eventInstance = new LoadUsersEvent(loadUsers.Entity.Id, hashSet);
				ScheduleEvent(eventInstance, session);
			}
			else
			{
				ScheduleEvent<UsersLoadedInternalEvent>(loadUsers);
			}
		}

		[OnEventFire]
		public void ReSendUsersLoaded(UsersLoadedEvent e, SingleNode<ClientSessionComponent> session)
		{
			EntityRegistry entityRegistry = Flow.Current.EntityRegistry;
			if (entityRegistry.ContainsEntity(e.RequestEntityId))
			{
				ScheduleEvent<UsersLoadedInternalEvent>(entityRegistry.GetEntity(e.RequestEntityId));
			}
		}

		[OnEventFire]
		public void UserLoaded(UsersLoadedInternalEvent e, SingleNode<LoadUserComponent> loadUsers)
		{
			loadUsers.Entity.AddComponent(new UserLoadedComponent(loadUsers.component.UserId));
		}

		[OnEventFire]
		public void UsersLoaded(UsersLoadedInternalEvent e, SingleNode<LoadUsersComponent> loadUsers)
		{
			loadUsers.Entity.AddComponent(new UsersLoadedComponent(loadUsers.component.UserIds));
		}

		[OnEventFire]
		public void UnLoadUser(NodeRemoveEvent e, SingleNode<LoadUserComponent> loadUser, [JoinAll] SingleNode<SharedUsersStorageComponent> storage, [JoinAll] SingleNode<ClientSessionComponent> session)
		{
			storage.component.UserId2EntityIdMap.Remove(loadUser.component.UserId, loadUser.Entity.Id);
			if (!storage.component.UserId2EntityIdMap.ContainsKey(loadUser.component.UserId))
			{
				UnLoadUsersEvent eventInstance = new UnLoadUsersEvent(loadUser.component.UserId);
				ScheduleEvent(eventInstance, session);
			}
		}

		[OnEventFire]
		public void UnLoadUsers(NodeRemoveEvent e, SingleNode<LoadUsersComponent> loadUsers, [JoinAll] SingleNode<SharedUsersStorageComponent> storage, [JoinAll] SingleNode<ClientSessionComponent> session)
		{
			HashSet<long> hashSet = new HashSet<long>();
			foreach (long userId in loadUsers.component.UserIds)
			{
				storage.component.UserId2EntityIdMap.Remove(userId, loadUsers.Entity.Id);
				if (!storage.component.UserId2EntityIdMap.ContainsKey(userId))
				{
					hashSet.Add(userId);
				}
			}
			if (hashSet.Count > 0)
			{
				UnLoadUsersEvent eventInstance = new UnLoadUsersEvent(hashSet);
				ScheduleEvent(eventInstance, session);
			}
		}
	}
}
