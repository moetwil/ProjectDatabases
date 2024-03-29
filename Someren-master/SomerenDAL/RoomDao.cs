﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class RoomDao : BaseDao
    {      

        // select all rooms from the database
        public List<Room> GetAllRooms()
        {
            // SQL query that selects the information that we need, where the roomId is bigger than 200
            string query = "SELECT roomId, capacity, roomType FROM [Rooms] WHERE roomId > 200";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            // give error if the datatable is empty
            if (dataTable == null)
                throw new Exception("Datatable is empty");

            foreach (DataRow dr in dataTable.Rows)
            {
                // create a room with with information from the database and add it to the list
                Room room = new Room()
                {
                    Number = (int)dr["roomId"],
                    Capacity = (int)dr["capacity"],
                    Type = (bool)dr["roomType"]
                };

                rooms.Add(room);
            }

            // give error if the list of rooms is empty
            if (rooms.Count == 0)
                throw new Exception("No rooms loaded from the database");

            return rooms;
        }
    }
}
