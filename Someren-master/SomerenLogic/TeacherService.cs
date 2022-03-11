using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class TeacherService
    {
        TeacherDao teacherdb;

        // create teacher database connection
        public TeacherService()
        {
            teacherdb = new TeacherDao();
        }

        // load a list of teachers
        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = teacherdb.GetAllTeachers();

            if(teachers.Count == 0)
            {
                throw new Exception("Not loaded from database");
            }

            return teachers;
        }
    }
}
