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
        public List<SomerenModel.Teacher> GetAllStudents()
        {
            string query = "SELECT teacherId, firstName, lastName, roomId FROM [Teachers]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

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
            return teachers;
        }
    }
}
