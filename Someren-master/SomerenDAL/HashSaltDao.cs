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
    public class HashSaltDao : BaseDao
    {

        // create an hashsalt from the datatable give by the query
        private HashSalt ReadTables(DataTable dataTable)
        {
            // if the datatable is empty send error message
            if (dataTable == null)
                throw new Exception("Datatable is empty");

            HashSalt hashSalt = null;
            foreach (DataRow dr in dataTable.Rows)
            {
                // create an hashsalt with with information from the database and add it to the list
                hashSalt = new HashSalt()
                {
                    Hash = (string)dr["hash"],
                    Salt = (string)dr["salt"]
                };
            }
            return hashSalt;
        }
    }
}
