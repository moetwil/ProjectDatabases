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
    public class StudentService
    {
        StudentDao studentdb;

        // create student database connection
        public StudentService()
        {
            studentdb = new StudentDao();
        }

        // load a list of students
        public List<Student> GetStudents()
        {
            List<Student> students = studentdb.GetAllStudents();
            return students;
        }

        public List<Student> GetStudentsByActivity(int activityId)
        {
            List<Student> students = studentdb.GetStudentsByActivity(activityId);
            return students;
        }
    }
}
