using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Akka.Actor;
using MeetingRoom.Models;
using MeetingRoom.Services;

namespace MeetingRoom.Actors
{
	public class PersistUpdateActor : TypedActor, IHandle<Speak>
	{
		
		public void Handle(Speak message)
		{
			var _store = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IStoreConversations)) as IStoreConversations;
			_store.AddConversation(null, new Conversation
				{
					Message = message.Huh.Words,
					Permalink = Guid.NewGuid(),
					TimeCreated = message.Huh.When,
					UserCreated = message.Huh.Whom
				});
		}
	}
}