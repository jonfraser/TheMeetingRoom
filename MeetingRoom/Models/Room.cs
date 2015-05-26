using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingRoom.Models
{
	public class Room
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public Guid Permalink { get; set; }
		public string UserCreated { get; set; }

		public List<Conversation> ConversationThread { get; set; }
	}
}