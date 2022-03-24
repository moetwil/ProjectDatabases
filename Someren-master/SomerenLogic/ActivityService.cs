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
    public class ActivityService
    {
        ActivityDao activitydb;

        public ActivityService()
        {
            activitydb = new ActivityDao();
        }

        public List<Activity> GetActivities()
        {
            // collect all rooms from the database
            List<Activity> activities = activitydb.GetAllActivities();

            if (activities.Count == 0)
                throw new Exception("No activities loaded from the database.");

            return activities;
        }

        // add student to activity
        public void AddStudent(int activityId, int studentId)
        {
            activitydb.AddStudent(activityId, studentId);
        }

        // delete student from activity
        public void DeleteStudent(int activityId, int studentId)
        {
            activitydb.DeleteStudent(activityId, studentId);
        }

        // check if a student is in an activity
        public bool IsInActivity(int activityId, int studentId)
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudentsByActivity(activityId);

            bool isInActivity = false;
            foreach (Student student in students)
            {
                if (student.StudentId == studentId)
                    isInActivity = true;
            }

            return isInActivity;
        }

        
        // add supervisor to activity
        public void AddSupervisor(int activityId, int teacherId)
        {
            activitydb.AddSupervisor(activityId, teacherId);
        }

        // delete supervisor from activity
        public void DeleteSupervisor(int activityId, int teacherId)
        {
            activitydb.DeleteSupervisor(activityId, teacherId);
        }

        // checks if a supervisor is in an activity
        public bool SupervisorInActivity(int activityId, int teacherId)
        {
            TeacherService teacherService = new TeacherService();
            List<Teacher> teachers = teacherService.GetTeacherByActivity(activityId);

            bool supervisorInActivity = false;
            foreach (Teacher teacher in teachers)
            {
                if (teacher.TeacherId == teacherId)
                    supervisorInActivity = true;
            }

            return supervisorInActivity;
        }

        public void DeleteActivity(int activityId)
        {
            activitydb.DeleteActivity(activityId);
        }

        public void AddActivity(string description, string startDateTime, string endDateTime)
        {
            activitydb.AddActivity(description, startDateTime, endDateTime);
        }



    }
}
