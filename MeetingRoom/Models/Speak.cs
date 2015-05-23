using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Akka.Actor;

namespace MeetingRoom.Models
{
	public class Speak
	{
		public Speak(Speech huh)
		{
			Huh = huh;
		}

		public Speech Huh { get; private set; }
	}

	public class Speech
	{
		public string Words { get; set; }
		public string Whom { get; set; }
		public DateTime When { get; set; }
	}

	//public class SpeakActor : ReceiveActor
	//{
	//	public SpeakActor()
	//	{
	//		Receive<Speak>(speak => Debug.Write(speak.Words));
	//	}
	//}
}