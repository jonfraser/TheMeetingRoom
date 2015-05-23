using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Akka.Actor;
using Autofac.Integration.Mvc;
using MeetingRoom.Actors;
using MeetingRoom.Models;

namespace MeetingRoom.Controllers
{
	public class HomeController : Controller
	{
		private readonly IActorRef _speaker;
		private readonly IActorRef _emailer;
		private readonly IActorRef _saver;
		public HomeController(IActorRef LiveUpdateSpeaker, IActorRef EmailUpdateSpeaker, IActorRef PersistanceSpeaker)
		{
			_speaker = LiveUpdateSpeaker;
			_emailer = EmailUpdateSpeaker;
			_saver = PersistanceSpeaker;
		}
		public ActionResult Room(string id)
		{
			return View();
		}

		[HttpPost]
		public ActionResult Speak(string words)
		{
			var speak = new Speak(new Speech { Words = words, When = DateTime.UtcNow, Whom = User.Identity.Name });
			_speaker.Tell(speak);
			_saver.Tell(speak);
			_emailer.Tell(speak);
			return new HttpStatusCodeResult(200);
		}

		public ActionResult Rooms()
		{
			return View();
		}
	}
}