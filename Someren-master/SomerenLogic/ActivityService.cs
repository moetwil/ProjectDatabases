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


        
    }
}
