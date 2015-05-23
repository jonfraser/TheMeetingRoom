using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Akka.Actor;
using MeetingRoom.Models;

namespace MeetingRoom.Actors
{
	public class EmailUpdateActor : TypedActor, IHandle<Speak>
	{
		public void Handle(Speak message)
		{
			//TODO: Send an email
			Trace.Write("Sending an email... " + message.Huh.Words);
		}
	}
}