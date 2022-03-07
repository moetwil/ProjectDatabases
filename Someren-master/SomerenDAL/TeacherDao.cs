using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class TeacherDao : BaseDao
    {
        public List<SomerenModel.Teacher> GetAllStudents()
        {
            string query = "SELECT student_id, student_name FROM [TABLE]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<SomerenModel.Teacher> ReadTables(DataTable dataTable)
        {
            List<SomerenModel.Teacher> teachers = new List<SomerenModel.Teacher>();

            foreach (DataRow dr in dataTable.Rows)
            {
                SomerenModel.Teacher teacher = new SomerenModel.Teacher()
                {
                    int teacherId = (int)dr["teacherId"],
                    string firstName = (string)(dr["firstName"].ToString()),
                    string lastName = (string)(dr["lastName"].ToString()),
                    int roomdId = (int)dr["roomId"],
                };
                teachers.Add(teacher);
            }
            return teachers;
        }
    }
}
