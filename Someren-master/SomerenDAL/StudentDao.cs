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
    public class StudentDao : BaseDao
    {      
        // get all the students from the database
        public List<Student> GetAllStudents()
        {
            string query = "SELECT studentId, firstName, lastName, class, dateOfBirth, roomId FROM [Students]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Student> GetStudentsByActivity(int activityId)
        {
            string query = "SELECT Students.studentId, Students.firstName, Students.lastName, Students.class, Students.dateOfBirth, Students.roomId " +
                "FROM [Students] " +
                "INNER JOIN [ActivityStudent] ON ActivityStudent.studentId = Students.studentId " +
               $"WHERE [activityId] = {activityId}";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            //sqlParameters[0] = new SqlParameter("@ActivityId", activityId);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            // fill a student object with data from the database
            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    StudentId = (int)dr["studentId"],
                    FirstName = (string)(dr["firstName"].ToString()),
                    LastName = (string)(dr["lastName"].ToString()),
                    Class = (string)(dr["class"].ToString()),
                    DateOfBirth = (DateTime)dr["dateOfBirth"],
                    RoomId = (int)dr["roomId"]
                };
                students.Add(student);

                // if the students List is empty return an error message
                if (students.Count == 0) {
                    throw new Exception("No students loaded from the database");
                }
            }
            return students;
        }
    }
}
