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
    public class UserDao : BaseDao
    {
        // select all rooms from the database
        public User GetUserByUsername(string username)
        {
            // SQL query that selects the information that we need, where the roomId is bigger than 200
            string query = "SELECT [username], [hash], [salt], [question], [answer] FROM Users WHERE [username] = @Username";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Username", username);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private User ReadTables(DataTable dataTable)
        {
            // if the datatable is empty send error message
            if (dataTable == null)
                throw new Exception("Datatable is empty");

            User user = null;
            foreach (DataRow dr in dataTable.Rows)
            {
                // create a purchase with with information from the database and add it to the list
                

                user = new User()
                {
                    Username = (string)dr["username"],
                    HashSalt = new HashSalt((string)dr["hash"], (string)dr["salt"]),
                    Question = (string)dr["question"],
                    Answer = (string)dr["answer"]
                };
            }
            return user;
        }


    }
}
