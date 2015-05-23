using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Akka.Actor;
using MeetingRoom.Models;

namespace MeetingRoom.Actors
{
	public class ActionBotActor : TypedActor, IHandle<Speak>
	{
		public void Handle(Speak message)
		{
			//TODO: Analyse the message to see if it something needs to be done
			Trace.Write("I should check to see if you want me to do something like restart a service... ");
		}
	}
}