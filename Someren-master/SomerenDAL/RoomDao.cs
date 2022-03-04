using System;
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
        public List<Room> GetAllRooms()
        {
            string query = "SELECT roomId, capacity, roomType FROM [Rooms] WHERE roomId > 200";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> students = new List<Room>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Room room = new Room()
                {
                    Number = (int)dr["roomId"],
                    Capacity = (int)dr["capacity"],
                    Type = (bool)dr["roomType"]
                    
                };
                students.Add(room);
            }
            return students;
        }
    }
}
