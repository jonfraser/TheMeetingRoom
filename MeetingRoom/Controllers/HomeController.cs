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
using MeetingRoom.Services;

namespace MeetingRoom.Controllers
{
	public class HomeController : Controller
	{
		private readonly IActorRef _speaker;
		private readonly IActorRef _emailer;
		private readonly IActorRef _saver;
		private readonly IStoreConversations _store;

		public HomeController(IActorRef LiveUpdateSpeaker, IActorRef EmailUpdateSpeaker, IActorRef PersistanceSpeaker, IStoreConversations store)
		{
			_speaker = LiveUpdateSpeaker;
			_emailer = EmailUpdateSpeaker;
			_saver = PersistanceSpeaker;
			_store = store;
		}
		public ActionResult Room(Guid permalink)
		{
			return View(_store.GetRoom(permalink));
		}

		[HttpPost]
		public ActionResult Speak(string words, Guid roomPermalink)
		{
			var speak = new Speak(new Speech {	Words = words, 
												When = DateTime.UtcNow, 
												Whom = User.Identity.Name,
												RoomPermalink = roomPermalink});
			_speaker.Tell(speak);
			_saver.Tell(speak);
			_emailer.Tell(speak);
			return new HttpStatusCodeResult(200);
		}

		public ActionResult Rooms()
		{
			return View(_store.GetRooms());
		}
	}
}