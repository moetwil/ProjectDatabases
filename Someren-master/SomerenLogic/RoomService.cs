using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class RoomService
    {
        RoomDao roomdb;

        public RoomService()
        {
            roomdb = new RoomDao();
        }

        public List<Room> GetRooms()
        {
            // collect all rooms from the database
            List<Room> rooms = roomdb.GetAllRooms();
            return rooms;
        }

        
        public string IsTeacherRoom(Room room)
        {
            // returns a string with the correct type of room
            if (room.Type)
                return "Teacher Room";

            return "Student Room";
        }

        
    }
}
