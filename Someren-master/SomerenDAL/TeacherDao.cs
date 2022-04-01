using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;

namespace SomerenDAL
{
    public class TeacherDao : BaseDao
    {
        public List<Teacher> GetAllTeachers()
        {
            // getting the information about Teachers
            string query = "SELECT teacherId, firstName, lastName, roomId FROM [Teachers]";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // if the query or parameter is zero, than there will be an exception
            if(query.Length == 0)
            {
                throw new Exception("information from the database has not been loaded correctly.");
            }

            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Teacher> GetTeacherByActivity(int activityId)
        {
            string query = "SELECT Teachers.teacherId, Teachers.firstName, Teachers.lastName, Teachers.roomId " +
                "FROM Teachers " +
                "INNER JOIN[ActivitySupervisor] ON ActivitySupervisor.teacherId = Teachers.teacherId " +
                "WHERE[activityId] = @ActivityId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ActivityId", activityId);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            // linking teacher field to database and adding it to the list
            List<Teacher> teachers = new List<Teacher>();

            // fill a teacher object with data from the database
            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher()
                {
                    TeacherId = (int)dr["teacherId"],
                    FirstName = (string)(dr["firstName"].ToString()),
                    LastName = (string)(dr["lastName"].ToString()),
                    RoomId = (int)dr["roomId"],
                };
                teachers.Add(teacher);
            }

            // if the teacher list is not found than there will be an exception
            if(teachers.Count == 0)
            {
                throw new Exception("information about the teachers has not been found.");
            }

            return teachers;
        }
    }
}
