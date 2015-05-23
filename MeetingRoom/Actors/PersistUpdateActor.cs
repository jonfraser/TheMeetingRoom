using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Akka.Actor;
using MeetingRoom.Models;

namespace MeetingRoom.Actors
{
	public class PersistUpdateActor : TypedActor, IHandle<Speak>
	{
		public void Handle(Speak message)
		{
			//TODO: Save to database
			Trace.Write("Saving to database... " + message.Huh.Words);
		}
	}
}