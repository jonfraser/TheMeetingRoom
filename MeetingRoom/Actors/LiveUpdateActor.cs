using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Akka.Actor;
using MeetingRoom.Hubs;
using MeetingRoom.Models;
using Microsoft.AspNet.SignalR;

namespace MeetingRoom.Actors
{

	public class LiveUpdateActor : TypedActor, IHandle<Speak>
	{
		public void Handle(Speak message)
		{
			var hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			hubContext.Clients.All.chatMessageReceived(message.Huh.Words,
														message.Huh.Whom,
														message.Huh.When.ToLocalTime().ToString("dd-MMM-yyyy hh:mm:ss"));
		}
	}
}