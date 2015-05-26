using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeetingRoom.Models;

namespace MeetingRoom.Services
{
	public interface IStoreConversations
	{
		IEnumerable<Room> GetRooms();
		Room GetRoom(Guid permalink);
		IEnumerable<Conversation> GetRoomConversation(Guid roomPermalink);
		Room CreateRoom(string roomName, string userName);
		void AddConversation(Room room, Conversation conversation);
	}
}