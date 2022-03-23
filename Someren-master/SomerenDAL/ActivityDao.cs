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
    public class ActivityDao : BaseDao
    {      
        public List<Activity> GetAllActivities()
        {
            // SQL query that selects the information that we need for all activities
            string query = "SELECT [activityId], [description], startDateTime, endDateTime FROM [Activities]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // add a student to an activity
        public void AddStudent(int activityId, int studentId)
        {
            string query = "INSERT INTO [ActivityStudent] ([studentId], [activityId]) VALUES (@StudentId, @ActivityId)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@StudentId", studentId);
            sqlParameters[1] = new SqlParameter("@ActivityId", activityId);
            ExecuteEditQuery(query, sqlParameters);
        }


        // delete a student from an activity
        public void DeleteStudent(int activityId, int studentId)
        {
            string query = "DELETE FROM [ActivityStudent] WHERE [studentId] = @StudentId AND [activityId] = @ActivityId;";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@StudentId", studentId);
            sqlParameters[1] = new SqlParameter("@ActivityId", activityId);
            ExecuteEditQuery(query, sqlParameters);
        }

        
        //add a supervisor to an activity
        public void AddSupervisor(int activityId, int teacherId)
        {
            string query = "INSERT INTO [ActivityTeacher] ([teacherId], [activityId]) VALUES (@TeacherId, @ActivityId)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@TeacherId", teacherId);
            sqlParameters[1] = new SqlParameter("@ActivityId", activityId);
            ExecuteEditQuery(query, sqlParameters);
        }

        // delete a student from an activity
        public void DeleteSupervisor(int activityId, int teacherId)
        {
            string query = "DELETE FROM [ActivityTeacher] WHERE [teacherId] = @TeacherId AND [activityId] = @ActivityId;";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@TeacherId", teacherId);
            sqlParameters[1] = new SqlParameter("@ActivityId", activityId);
            ExecuteEditQuery(query, sqlParameters);
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            if (dataTable == null)
                throw new Exception("Datatable is empty");

            foreach (DataRow dr in dataTable.Rows)
            {
                // create an activity with with information from the database and add it to the list
                Activity activity = new Activity()
                {
                    ActivityId = (int)dr["activityId"],
                    Description = (string)dr["description"],
                    StartDateTime = (DateTime)dr["startDateTime"],
                    EndDateTime = (DateTime)dr["endDateTime"]
                };
                activities.Add(activity);
            }

            return activities;
        }
    }
}
