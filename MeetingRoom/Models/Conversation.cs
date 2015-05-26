using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingRoom.Models
{
	public class Conversation
	{
		public int ID { get; set; }
		public Room Room { get; set; }
		public int RoomID { get; set; }
		public Guid Permalink { get; set; }
		public string UserCreated { get; set; }
		public DateTime TimeCreated { get; set; }
		public string Message { get; set; }

	}
}