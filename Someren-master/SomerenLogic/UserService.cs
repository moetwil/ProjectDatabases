using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class UserService
    {
        UserDao userdb;

        public UserService()
        {
            this.userdb = new UserDao();
        }

        public User GetUser(string username)
        {
            return userdb.GetUserByUsername(username);
        }
    }
}
