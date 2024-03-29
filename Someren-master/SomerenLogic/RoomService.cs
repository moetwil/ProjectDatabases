﻿using SomerenDAL;
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

        // create room database connection
        public RoomService()
        {
            roomdb = new RoomDao();
        }

        public List<Room> GetRooms()
        {
            // collect all rooms from the database
            List<Room> rooms = roomdb.GetAllRooms();

            if (rooms.Count == 0)
                throw new Exception("No rooms loaded from the database.");

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
